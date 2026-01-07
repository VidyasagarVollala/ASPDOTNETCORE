namespace StocksApp.ServiceContracts
{
    public interface IFinhubServices
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
