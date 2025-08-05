using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;

namespace BanReservas.API.Application.Services
{
    public class ExchangeService : IExchangeService
    {
        public async Task<decimal> GetExchangeRateAsync(ExchangeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.SourceCurrency))
                throw new ArgumentException("La tasa origen es requerida");
            if (string.IsNullOrWhiteSpace(request.TargetCurrency))
                throw new ArgumentException("La tasa destino es requerida");
            if (request.Amount <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero");

            var random = new Random();
            var rate = (decimal)(random.NextDouble() * (60 - 50) + 50); // tasa entre 50 y 60
            return Math.Round(rate, 2) * request.Amount;
        }
    }
}
