using StocksApp.ServiceContracts;
using System.Text;
using System.Text.Json;

namespace StocksApp.Services
{
    public class FinhubServices : IFinhubServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;

        public FinhubServices(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{_configuration["FinHubURL"]}/quote?symbol={stockSymbol}&token={_configuration["FinHubAPIToken"]}"),
                    Method = HttpMethod.Get,
                };

                HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponse.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                string response = reader.ReadToEnd();

                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                    throw new InvalidOperationException("No response from finhub server");

                if (responseDictionary.ContainsKey("error"))
                    throw new InvalidOperationException($"{responseDictionary["error"]}");

                return responseDictionary;

            }



        }
    }
}
