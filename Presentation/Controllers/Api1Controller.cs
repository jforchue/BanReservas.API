using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BanReservas.API.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class Api1Controller : ControllerBase
{
    private readonly IApi1ExchangeProvider _exchangeProvider;
    public Api1Controller(IApi1ExchangeProvider exchangeProvider)
    {
        _exchangeProvider = exchangeProvider ?? throw new ArgumentNullException(nameof(exchangeProvider));
    }

    [HttpPost("rate")]
    public async Task<IActionResult> GetRate(Api1ExchangeRequest request)
    {
        try
        {
            var rate = await _exchangeProvider.GetExchangeRateAsync(request);
            var response = new Api1ExchangeResponse() { Rate = rate };
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Hubo un error la procesar la solicitud");
        }
    }
}
