using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class BitcoinAddress : IAddress
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name="total_confirmed")]
        public String TotalConfirmed { get; set; }

        [DataMember(Name = "total_received")]
        public String TotalReceived { get; set; }

        [DataMember(Name="address")]
        public string Address { get; set; }
    }
}
