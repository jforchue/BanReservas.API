using BanReservas.API.Domain;
using BanReservas.API.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api1ExchangeService : IExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSetting _settings;
        public Api1ExchangeService(HttpClient httpClient, IOptions<ExchangeApiSetting> config)
        {
            _httpClient = httpClient;
            _settings = config.Value.Api1;
        }

        public async Task<decimal> GetExchangeRateAsync(RateRequest request)
        {
            var requestBody = new
            {
                from = request.From,
                to = request.To,
                value = request.Value
            };

            var response = await _httpClient.PostAsJsonAsync(_settings.Url, requestBody);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Api1Response>();
            return result?.Rate ?? 0m;
        }
    }
}
