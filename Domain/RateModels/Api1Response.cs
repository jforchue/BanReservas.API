using System.Xml.Serialization;

namespace BanReservas.API.Domain
{
    //public class Api2Response
    //{
    //    public Data XML { get; set; }
    //}

    [XmlRoot("XML")]
    public class Api2Response
    {
        [XmlElement("Result")]

        public decimal Result { get; set; }
    }
}
