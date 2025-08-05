using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BanReservas.API.Domain.Models
{
    public class XML 
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}
