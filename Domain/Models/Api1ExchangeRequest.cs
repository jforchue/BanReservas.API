using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BanReservas.API.Domain.Models
{
    public class Api1ExchangeRequest 
    {
        public Api1ExchangeRequest()
        {
            
        }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }

    }
}
