namespace BanReservas.API.Domain.Interfaces
{
    public interface IExternalService
    {
        Task<decimal> GetExchangeRateAsync(RateRequest request);
    }
}
