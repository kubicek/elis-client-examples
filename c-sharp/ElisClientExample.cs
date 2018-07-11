using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace elis_example_c_sharp
{
    [DataContract]
    class Result
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string message { get; set; }
    }
    class ElisClientExample
    {
        private HttpClient client = new HttpClient();
        private string host;
        private string secretKey;

        public ElisClientExample(string secretKey, string host)
        {
            this.host = host;
            this.secretKey = secretKey;
            client.DefaultRequestHeaders.Add("Authorization", "secret_key " + secretKey);
        }

        public static void Main(string[] args)
        {
            if (args.Length != 3) {
                Console.WriteLine("Usage: dotnet run -- DOCUMENT_PATH ELIS_API_HOST SECRET_KEY");
                Console.WriteLine("Example: dotnet run -- invoice.pdf https://all.rir.rossum.ai xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx");
                Environment.Exit(-1);
            }
            var filePath = args[0]; // can be a PDF or PNG
            var host = args[1];
            var secretKey = args[2];
            var elisClient = new ElisClientExample(secretKey, host);
            elisClient.SubmitInvoiceAndWaitForResult(filePath).Wait();
        }
        
        public async Task SubmitInvoiceAndWaitForResult(string filePath)
        {
            var documentId = await SubmitInvoice(filePath);
            var extractedInvoice = await GetInvoice(documentId);
            Console.WriteLine(extractedInvoice);
            // now you can process the invoice extracted by Elis API...
        }

        // Submits the invoice from a file to the Elis API, returns a document id.
        public async Task<string> SubmitInvoice(string filePath)
        {
            FileStream fs = File.OpenRead(filePath);
            Console.WriteLine("Submitting invoice: " + filePath);
            var ext = Path.GetExtension(filePath).ToLower();
            var mediaType = (ext == ".png") ? "image/png" : "application/pdf";
            var fileContent = new StreamContent(fs);
            Console.WriteLine("Media type: " + mediaType);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mediaType);
            var multiPartContent = new MultipartFormDataContent {
                {fileContent, "file", Path.GetFileName(filePath)}
            };
            var response = await client.PostAsync(host + "/document", multiPartContent);
            Console.WriteLine("HTTP status code: " + response.StatusCode);
            await CheckResponse(response);

            var serializer = new DataContractJsonSerializer(typeof(Result));
            var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as Result;

            Console.WriteLine("Submitted invoice with id: " + result.id);

            return result.id;
        }

        // Given submitted document id it polls for invoice to be processed, returns the processd invoice in JSON.
        public async Task<string> GetInvoice(String invoiceId, int maxTries=30, int sleepMillis=5000)
        {
            for (int i = 0; i < maxTries; i++)
            {
                Console.WriteLine("Waiting for invoice: " + (i * sleepMillis * 1e-3) + " s / " + (maxTries * sleepMillis * 1e-3) + " s");
                var response = await client.GetAsync(host + "/document/" + invoiceId);
                await CheckResponse(response);
                var serializer = new DataContractJsonSerializer(typeof(Result));
                var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as Result;
                Console.WriteLine("status: " + result.status + ", message: " + result.message);
                switch (result.status) {
                    case "processing":
                        await Task.Delay(sleepMillis);
                        break;
                    case "ready":
                        return await response.Content.ReadAsStringAsync();
                    case "error":
                        throw new Exception("Error while processing invoice " + invoiceId + ": " + result.message);
                }
            }
            throw new Exception("Time out while waiting for the invoice the be processed.");
        }

        private async Task CheckResponse(HttpResponseMessage response) {
            if (response.StatusCode != HttpStatusCode.OK) {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                Environment.Exit(-2);
            }
        }
    }
}
