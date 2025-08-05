using BanReservas.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Provider.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeController : ControllerBase
{
    [HttpPost("rate")]
    public IActionResult GetBestOffer([FromBody] ExchangeRequest request)
    {
        return Ok();
    }
}
