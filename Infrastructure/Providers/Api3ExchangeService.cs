using BanReservas.API.Domain;
using BanReservas.API.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api3ExchangeService : IExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSetting _settings;

        public Api3ExchangeService(HttpClient httpClient, IOptions<ExchangeApiSetting> config)
        {
            _httpClient = httpClient;
            _settings = config.Value.Api3;
        }

        public async Task<decimal> GetExchangeRateAsync(RateRequest request)
        {
            var requestBody = new Api3Request
            {
                exchange = new Api3Exchange
                {
                    sourceCurrency = request.From,
                    targetCurrency = request.To,
                    quantity = request.Value
                }
            };

            var requestJson = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_settings.Url, content);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Api3Response>(responseJson);

            return result?.data?.total ?? throw new Exception("Invalid API3 response");
        }
    }
}
