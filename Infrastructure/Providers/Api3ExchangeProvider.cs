using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api3ExchangeProvider : IApi3ExchangeProvider
    {
        private readonly IExchangeService _exchangeService;

        public Api3ExchangeProvider(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService ?? throw new ArgumentNullException(nameof(exchangeService));
        }

        public async Task<decimal> GetExchangeRateAsync(Api3ExchangeRequest request)
        {
            return await _exchangeService.GetExchangeRateAsync(new ExchangeRequest()
            {
                SourceCurrency = request.exchange.SourceCurrency,
                TargetCurrency = request.exchange.TargetCurrency,
                Amount = request.exchange.Quantity
            });
        }
    }
}
