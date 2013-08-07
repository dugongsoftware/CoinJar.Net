using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class AddressesResponse
    {
        [DataMember(Name = "bitcoin_addresses")]
        public IList<IAddress> BitcoinAddresses { get; set; }
    }
}
