using BanReservas.API.Domain.Models;

namespace BanReservas.API.Domain.Interfaces
{
    public interface IExchangeService
    {
        Task<decimal> GetExchangeRateAsync(ExchangeRequest request);
    }
}
