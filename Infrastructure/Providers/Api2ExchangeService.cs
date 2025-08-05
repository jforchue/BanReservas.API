using BanReservas.API.Domain;
using BanReservas.API.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api2ExchangeService : IExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSetting _settings;

        public Api2ExchangeService(HttpClient httpClient, IOptions<ExchangeApiSetting> config)
        {
            _httpClient = httpClient;
            _settings = config.Value.Api2;
        }

        public async Task<decimal> GetExchangeRateAsync(RateRequest request)
        {
            string xmlBody = @$"<XML><From>{request.From}</From><To>{request.To}</To><Amount>{request.Value}</Amount></XML>";

            var content = new StringContent(xmlBody, Encoding.UTF8, "application/xml");

            var response = await _httpClient.PostAsync(_settings.Url, content);
            response.EnsureSuccessStatusCode();

            string i = await response.Content.ReadAsStringAsync();

            var stream = await response.Content.ReadAsStreamAsync();
            var deserializer = new XmlSerializer(typeof(Api2Response));
            var result = (Api2Response)deserializer.Deserialize(stream)!;

            return result.Result;
        }
    }
}
