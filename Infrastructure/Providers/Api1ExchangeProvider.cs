using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api1ExchangeProvider : IApi1ExchangeProvider
    {
        private readonly IExchangeService _exchangeService;

        public Api1ExchangeProvider(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService ?? throw new ArgumentNullException(nameof(exchangeService));
        }

        public async Task<decimal> GetExchangeRateAsync(Api1ExchangeRequest request)
        {
            return await _exchangeService.GetExchangeRateAsync(new ExchangeRequest()
            {
                SourceCurrency = request.From,
                TargetCurrency = request.To,
                Amount = request.Value
            });
        }
    }
}
