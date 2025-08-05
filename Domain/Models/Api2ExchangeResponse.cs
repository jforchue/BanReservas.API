using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BanReservas.API.Domain.Models
{
    [XmlRoot("XML")]
    public class Api2ExchangeResponse
    {
        public decimal Result { get; set; }
    }
}
