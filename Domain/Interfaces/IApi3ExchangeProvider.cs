using BanReservas.API.Domain.Models;

namespace BanReservas.API.Domain.Interfaces
{
    public interface IApi3ExchangeProvider
    {
        Task<decimal> GetExchangeRateAsync(Api3ExchangeRequest request);
    }
}
