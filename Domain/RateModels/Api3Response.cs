namespace BanReservas.API.Domain
{
    public class Api3Response
    {
        public int statusCode { get; set; }
        public string message { get; set; } = string.Empty;
        public Api3Data data { get; set; } = new();
    }

    public class Api3Data
    {
        public decimal total { get; set; }
    }
}
