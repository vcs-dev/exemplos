using ConsoleApp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp.Requests
{
    public class MercadoLivreRequest
    {
        private readonly string _baseUrl = "https://lista.mercadolivre.com.br";

        public async Task<MercadoLivreSearchResponse> SearchProductOnMercadoLivreAsync(string product)
        {
            if (string.IsNullOrWhiteSpace(product))
                return new MercadoLivreSearchResponse();

            using var httpClient = new HttpClient();
            var responseObject = new MercadoLivreSearchResponse();

            var response = await httpClient.GetAsync($"{_baseUrl}/{product}");
            responseObject.StatusCode = (int)response.StatusCode;
            responseObject.Content = await response.Content.ReadAsStringAsync();
            responseObject.ContentType = response.Content.Headers.ContentType.ToString();

            return responseObject;
        }

        public async Task<MercadoLivreSearchResponse> SearchProductOnMercadoLivreAsync(string product, string location)
        {
            if (string.IsNullOrWhiteSpace(product) || string.IsNullOrWhiteSpace(location))
                return new MercadoLivreSearchResponse();

            using var httpClient = new HttpClient();
            var responseObject = new MercadoLivreSearchResponse();
            var routeParameters = $"{location}/{product}";

            var response = await httpClient.GetAsync($"{_baseUrl}/{routeParameters}");
            responseObject.StatusCode = (int)response.StatusCode;
            responseObject.Content = await response.Content.ReadAsStringAsync();
            responseObject.ContentType = response.Content.Headers.ContentType.ToString();

            return responseObject;
        }
    }
}
