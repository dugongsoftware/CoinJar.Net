using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class AddressResponse
    {
        [DataMember(Name = "bitcoin_address")]
        public BitcoinAddress BitcoinAddress { get; set; }
    }
}
