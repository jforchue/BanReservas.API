using BanReservas.API.Domain.Models;

namespace BanReservas.API.Domain.Interfaces
{
    public interface IApi2ExchangeProvider
    {
        Task<decimal> GetExchangeRateAsync(XML request);
    }
}
