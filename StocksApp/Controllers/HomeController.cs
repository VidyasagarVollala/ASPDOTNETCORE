using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Model;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinhubServices _finhubServices;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public HomeController(FinhubServices finhubServices, IOptions<TradingOptions> tradingOptions)
        {
            _finhubServices = finhubServices;
            _tradingOptions = tradingOptions;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            _tradingOptions.Value.DefaultStockSymbol ??= "MSFT";

            Dictionary<string, object>? responseDictonary = await _finhubServices.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

            Stocks stocks = new Stocks()
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice= Convert.ToDouble(responseDictonary["c"].ToString()),
                HighestPrice = Convert.ToDouble(responseDictonary["h"].ToString()),
                LowestPrie = Convert.ToDouble(responseDictonary["l"].ToString()),
                OpenPrice = Convert.ToDouble(responseDictonary["o"].ToString())

            };


            return View(stocks);
        }
    }
}
 

