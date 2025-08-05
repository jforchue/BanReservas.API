using BanReservas.API.Application.Services;
using BanReservas.API.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Api1.Provider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RateController : ControllerBase
{
    private readonly RateService _rateService;
    public RateController(RateService rateService)
    {
        _rateService = rateService;
    }

    [HttpPost("rate")]
    public async Task<IActionResult> GetBestOffer([FromBody] RateRequest request)
    {
        var bestRate = await _rateService.GetBestRateAsync(request);
        return Ok(new { bestRate });
    }
}
