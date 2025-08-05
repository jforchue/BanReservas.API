using BanReservas.API.Domain.Models;

namespace BanReservas.API.Domain.Interfaces
{
    public interface IApi1ExchangeProvider
    {
        Task<decimal> GetExchangeRateAsync(Api1ExchangeRequest request);
    }
}
