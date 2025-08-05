namespace BanReservas.API.Domain
{
    public class Api3Request
    {
        public Api3Exchange exchange { get; set; } = new();
    }

    public class Api3Exchange
    {
        public string sourceCurrency { get; set; }
        public string targetCurrency { get; set; }
        public decimal quantity { get; set; }
    }

}
