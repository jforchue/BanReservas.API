using System.Xml.Serialization;

namespace BanReservas.API.Domain
{
    [XmlRoot("XML")]
    public class Api2Request
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}
