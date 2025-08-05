using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanReservas.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class Api3Controller : ControllerBase
{
    private readonly IApi3ExchangeProvider _exchangeProvider;

    public Api3Controller(IApi3ExchangeProvider exchangeProvider)
    {
        _exchangeProvider = exchangeProvider ?? throw new ArgumentNullException(nameof(exchangeProvider));
    }

    [HttpPost("rate")]
    public async Task<IActionResult> GetRate(Api3ExchangeRequest request)
    {
        try
        {
            var rate = await _exchangeProvider.GetExchangeRateAsync(request);
            
            var response = new Api3ExchangeResponse()
            {
                Data = new
                {
                    Total = rate
                },
                StatusCode = StatusCodes.Status200OK
            };

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
