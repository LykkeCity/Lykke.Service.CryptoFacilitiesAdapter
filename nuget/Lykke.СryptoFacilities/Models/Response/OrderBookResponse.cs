namespace Lykke.СryptoFacilities.Models.Response
{
    public class OrderBookResponse : BaseResponse
    {
        public OrderBook OrderBook { set; get; }
    }
    
    public class OrderBook
    {
        public decimal[][] Bids { set; get; }
        public decimal[][] Asks { set; get; }
    }
}
