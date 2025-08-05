using BanReservas.API.Application.Services;
using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;
using BanReservas.API.Infrastructure.Providers;
using BanReservas.API.Presentation.Controllers;
using Xunit;

namespace BanReservas.API.Test
{
    public class ApiTests
    {
        private readonly IExchangeService _service;
        private readonly IApi1ExchangeProvider _apiProvider;
        private readonly Api1Controller _api1Controller;
        public ApiTests()
        {
            _service = new ExchangeService();
            _apiProvider = new Api1ExchangeProvider(_service);
            _api1Controller = new Api1Controller(_apiProvider);
        }

        #region Validar parametros
        [Theory]
        [InlineData("", "USD", 20)]
        [InlineData("USD", "", 20)]
        [InlineData("USD", "DOP", 0)]
        [InlineData("", "", 0)]
        public async Task Validar_Parametros_Faltantes
            (string SourceCurrency, string TargetCurrency, decimal Amount)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetExchangeRateAsync(new ExchangeRequest()
            {
                SourceCurrency = SourceCurrency,
                TargetCurrency = TargetCurrency,
                Amount = Amount
            }));
        }

        [Theory]
        [InlineData("", "USD", 20, "La tasa origen es requerida")]
        [InlineData("USD", "", 20, "La tasa destino es requerida")]
        [InlineData("USD", "DOP", 0, "El monto debe ser mayor que cero")]
        public async Task Validar_Mensajes_Para_Parametros_Faltantes
            (string SourceCurrency, string TargetCurrency, 
            decimal Amount, string message)
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _service.GetExchangeRateAsync(new ExchangeRequest()
            {
                SourceCurrency = SourceCurrency,
                TargetCurrency = TargetCurrency,
                Amount = Amount
            }));

            Assert.Equal(ex.Message, message);
        }
        #endregion
    }
}
