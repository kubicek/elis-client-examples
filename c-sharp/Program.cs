using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace elis_example_c_sharp
{
    class Program
    {
        private static async Task GetInvoice(String invoiceId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "secret_key xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx");
                var getTask = client.GetStringAsync("https://all.rir.rossum.ai/document/" + invoiceId);
                var message = await getTask;
                Console.WriteLine(message);
            }
        }

        private static async Task SubmitInvoice()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "secret_key xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx");
                FileStream fs = File.OpenRead("invoice.pdf");
                var fileContent = new StreamContent(fs);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
                var multiPartContent = new MultipartFormDataContent
                    {
                        {fileContent, "file", "invoice.pdf"}
                    };
                var response = await client.PostAsync("https://all.rir.rossum.ai/document", multiPartContent);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        static void Main(string[] args)
        {
            SubmitInvoice().Wait();
            // GetInvoice("4f559192a954da7de6553df1").Wait();
        }
    }
}
