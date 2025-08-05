namespace BanReservas.API.Domain
{
    public class RateRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
    }
}
