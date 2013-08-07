using System;

namespace Providers
{
    public interface IExchange
    {
        Double GetRate(CurrencyCode code);
        String Buy(Double Amount, Double Rate);
        String BuyAtMarketRate(Double Amount);
        String Sell(Double Amount, Double Rate);
        String SellAtMarketRate(Double Amount);
    }
}