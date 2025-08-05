using BanReservas.API.Domain;
using BanReservas.API.Domain.Interfaces;

namespace BanReservas.API.Application.Services
{
    public class RateService
    {
        private readonly IEnumerable<IExternalService> _providers;

        public RateService(IEnumerable<IExternalService> providers)
        {
            _providers = providers;
        }

        public async Task<decimal> GetBestRateAsync(RateRequest request)
        {
            var tasks = _providers.Select(p => p.GetExchangeRateAsync(request));
            var results = await Task.WhenAll(tasks);

            return results.Max(); 
        }
    }
}
