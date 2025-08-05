using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BanReservas.API.Domain.Models
{
    public class Exchange 
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Quantity { get; set; }
    }
}
