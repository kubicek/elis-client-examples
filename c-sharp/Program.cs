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
    class Program
    {
        private HttpClient client = new HttpClient();
        private string host;
        private string secretKey;

        public Program(string secretKey, string host)
        {
            this.host = host;
            this.secretKey = secretKey;
            client.DefaultRequestHeaders.Add("Authorization", "secret_key " + secretKey);
        }

        private async Task<string> GetInvoice(String invoiceId)
        {
            var response = await client.GetAsync(host + "/document/" + invoiceId);
            var serializer = new DataContractJsonSerializer(typeof(Result));
            var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as Result;
            Console.WriteLine("status: " + result.status + ", message: " + result.message);
            var processedInvoice = await response.Content.ReadAsStringAsync();
            return processedInvoice;
        }

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
                // TODO: set file base name
                {fileContent, "file", "invoice.pdf"}
            };
            var response = await client.PostAsync(host + "/document", multiPartContent);
            Console.WriteLine("HTTP status code: " + response.StatusCode);

            var serializer = new DataContractJsonSerializer(typeof(Result));
            var result = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as Result;

            Console.WriteLine("Submitted invoice with id: " + result.id);

            return result.id;
        }
        private async Task SubmitInvoiceAndWaitForResult(string filePath)
        {
            var documentId = await SubmitInvoice(filePath);
            var processedInvoice = await GetInvoice(documentId);
            Console.WriteLine(processedInvoice);
        }

        static void Main(string[] args)
        {
            var secretKey = "xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx";
            var host = "https://all.rir.rossum.ai";
            var filePath = "invoice.pdf";
            new Program(secretKey, host).SubmitInvoiceAndWaitForResult(filePath).Wait();
        }
    }
}
