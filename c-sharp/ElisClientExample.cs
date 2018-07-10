using System;
using System.Collections.Generic;
using System.IO;
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

        static void Main(string[] args)
        {
            var secretKey = "xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx";
            var host = "https://all.rir.rossum.ai";
            var filePath = "invoice.pdf"; // can be a PDF or PNG
            var elisClient = new ElisClientExample(secretKey, host);
            elisClient.SubmitInvoiceAndWaitForResult(filePath).Wait();
        }

        private async Task SubmitInvoiceAndWaitForResult(string filePath)
        {
            var documentId = await SubmitInvoice(filePath);
            var extractedInvoice = await GetInvoice(documentId);
            Console.WriteLine(extractedInvoice);
            // now you can process the invoice extracted by Elis API...
        }

        // Submits the invoice from a file to the Elis API, returns a document id.
        private async Task<string> SubmitInvoice(string filePath)
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

            var serializer = new DataContractJsonSerializer(typeof(Result));
            var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as Result;

            Console.WriteLine("Submitted invoice with id: " + result.id);

            return result.id;
        }

        // Given submitted document id polls for invoice to be processed, returns the processd invoice in JSON.
        private async Task<string> GetInvoice(String invoiceId, int maxTries=30, int sleepMillis=5000)
        {
            for (int i = 0; i < maxTries; i++)
            {
                Console.WriteLine("Waiting for invoice: " + (i * sleepMillis * 1e-3) + " s / " + (maxTries * sleepMillis * 1e-3) + " s");
                var response = await client.GetAsync(host + "/document/" + invoiceId);
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
    }
}
