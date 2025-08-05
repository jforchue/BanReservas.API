using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;

namespace BanReservas.API.Infrastructure.Providers
{
    public class Api2ExchangeProvider : IApi2ExchangeProvider
    {
        private readonly IExchangeService _exchangeService;

        public Api2ExchangeProvider(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService ?? throw new ArgumentNullException(nameof(exchangeService));
        }

        public async Task<decimal> GetExchangeRateAsync(XML request)
        {
            return await _exchangeService.GetExchangeRateAsync(new ExchangeRequest()
            {
                SourceCurrency = request.From,
                TargetCurrency = request.To,
                Amount = request.Amount
            });
        }
    }
}
