using ConsoleApp.Requests;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var request = new MercadoLivreRequest();
            var response = await request.SearchProductOnMercadoLivreAsync("smartphone motorola");
            var folderPathAndFileName = @"D:\smartphone_motorola.html";

            if (!string.IsNullOrWhiteSpace(response.Content))
                await File.WriteAllTextAsync(folderPathAndFileName, response.Content);

            Console.WriteLine($"Status: {response.StatusCode}\nContent type: {response.ContentType}\nResposta html criada em: {folderPathAndFileName}");

            Console.WriteLine("==========================================================================================");

            response = await request.SearchProductOnMercadoLivreAsync(location: "sao-paulo", product: "smartphone motorola");

            folderPathAndFileName = @"D:\smartphone_motorola_sao_paulo.html";

            if (!string.IsNullOrWhiteSpace(response.Content))
                await File.WriteAllTextAsync(folderPathAndFileName, response.Content);

            Console.WriteLine($"Status: {response.StatusCode}\nContent type: {response.ContentType}\nResposta html criada em: {folderPathAndFileName}");
            Console.WriteLine("==========================================================================================");
        }
    }
}
