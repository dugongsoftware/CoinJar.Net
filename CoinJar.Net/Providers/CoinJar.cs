using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Providers
{
    public class CoinJar : BaseCoinJar, IAddress, IExchange, IPayment
    {
        private const string ADDRESS_REG_EX = "[1-3][a-zA-Z1-9]{26,33}";

        #region IAddress2 Members

        /// <summary>
        /// Get single address
        /// </summary>
        /// <param name="bitcoinAddress"></param>
        /// <returns></returns>
        public Models.IAddress GetAddress(String bitcoinAddress)
        {
            if (!String.IsNullOrEmpty(bitcoinAddress))
            {
                Match match = Regex.Match(bitcoinAddress, ADDRESS_REG_EX);

                if (match.Success == true)
                {
                    Uri url = new Uri(String.Format("https://api.coinjar.io/v1/bitcoin_addresses/{0}.json", bitcoinAddress));

                    Providers.JsonSerializer<Models.CoinJar.AddressResponse> serializer = new JsonSerializer<Models.CoinJar.AddressResponse>();
                    serializer.Proxy = base.Proxy;
                    serializer.Credentials = new NetworkCredential(base.ApiKey, "");

                    Models.CoinJar.AddressResponse response = serializer.GetObject(url);
                    return response.BitcoinAddress;
                }
                else
                {
                    throw new ArgumentException("Address does not appear to be valid");
                }
            }
            else
            {
                throw new ArgumentNullException("Address cannot be null or empty");
            }
        }

        /// <summary>
        /// Get wallet addresses.  https://developer.coinjar.io/display/CD/Bitcoin+Addresses
        /// </summary>
        /// <returns></returns>
        public IList<Models.IAddress> GetAddresses()
        {
            Uri url = new Uri("https://api.coinjar.io/v1/bitcoin_addresses.json");

            Providers.JsonSerializer<Models.CoinJar.AddressesResponse> serializer = new JsonSerializer<Models.CoinJar.AddressesResponse>();
            serializer.Proxy = base.Proxy;
            serializer.Credentials = new NetworkCredential(base.ApiKey, "");

            Models.CoinJar.AddressesResponse response = serializer.GetObject(url);
            return response.BitcoinAddresses;
        }

        /// <summary>
        /// Create a new btc address with label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public Models.IAddress CreateAddress(String label)
        {
            Uri url = new Uri("https://api.coinjar.io/v1/bitcoin_addresses.json");

            String postData = String.Format("label={0}", label);
            WebResponse response = base.Post(url, postData);

            //Get the stream containing content returned by the server.
            using (Stream responseStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();

                    // Clean up the streams.
                    reader.Close();
                    response.Close();

                    Providers.JsonSerializer<Models.CoinJar.AddressResponse> serializer = new JsonSerializer<Models.CoinJar.AddressResponse>();
                    Models.CoinJar.AddressResponse addressResponse = serializer.GetObjectFromString(responseFromServer);
                    return addressResponse.BitcoinAddress;
                }
            }
        }

        #endregion

        #region IExchange Members

        public double GetRate(CurrencyCode code)
        {
            Uri url = new Uri(String.Format("https://api.coinjar.io/v1/fair_rate/{0}.json", code));

            Providers.JsonSerializer<Models.CoinJar.FairRateResponse> serializer = new JsonSerializer<Models.CoinJar.FairRateResponse>();
            serializer.Proxy = base.Proxy;
            serializer.Credentials = new System.Net.NetworkCredential(base.ApiKey, "");

            Models.CoinJar.FairRateResponse response = serializer.GetObject(url);
            return response.Spot;
        }

        public string Buy(double Amount, double Rate)
        {
            throw new NotImplementedException();
        }

        public string BuyAtMarketRate(double Amount)
        {
            throw new NotImplementedException();
        }

        public string Sell(double Amount, double Rate)
        {
            throw new NotImplementedException();
        }

        public string SellAtMarketRate(double Amount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPayment Members

        public string SendPayment(String address, double amount)
        {
            return SendPayment(address, amount, "Dugong Software", 0.00F);
        }

        public string SendPayment(String address, double amount, string label)
        {
            return SendPayment(address, amount, label, 0.00F);
        }

        public string SendPayment(String address, double amount, string label, double fee)
        {
            if (amount > 0)
            {
                //https://api.coinjar.io/v1/payments.json POST
                //  -u pJ451Sk8tXz9LdUbGg1sobLUZuVzuJwdyr4sD3owFW4WYHxo: \
                //  -d payment[payee]=n1Pc4SRA4xmG1k3SejrmTAX3NynALcT6sq \
                //  -d payment[amount]=1.25


                Uri url = new Uri("https://api.coinjar.io/v1/payments.json");
                String postData = String.Format("payment[payee]={0}&payment[amount]={1}", address, amount);
                WebResponse response = base.Post(url, postData);

                //Get the stream containing content returned by the server.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();

                        // Clean up the streams.
                        reader.Close();
                        response.Close();

                        return responseFromServer;
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Amount must be postive");
            }
        }

        #endregion
    }
}
