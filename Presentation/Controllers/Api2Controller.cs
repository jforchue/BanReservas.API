using BanReservas.API.Domain.Interfaces;
using BanReservas.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BanReservas.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("application/xml")]
[Produces("application/xml")]
public class Api2Controller : ControllerBase
{
    private readonly IApi2ExchangeProvider _exchangeProvider;

    public Api2Controller(IApi2ExchangeProvider exchangeProvider)
    {
        _exchangeProvider = exchangeProvider ?? throw new ArgumentNullException(nameof(exchangeProvider));
    }

    [HttpPost("rate")]
    public async Task<IActionResult> GetRate(XML request)
    {
        try
        {
            var rate = await _exchangeProvider.GetExchangeRateAsync(request);
            var response = new Api2ExchangeResponse() { Result = rate };

            var serializer = new XmlSerializer(typeof(Api2ExchangeResponse));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true, 
                Indent = false,
                Encoding = new UTF8Encoding(false)
            };

            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb, settings))
            {
                serializer.Serialize(writer, response, namespaces);
            }

            return Content(sb.ToString(), "application/xml");
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
