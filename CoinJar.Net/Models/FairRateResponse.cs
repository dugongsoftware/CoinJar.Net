using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class FairRateResponse
    {
        [DataMember(Name = "bit")]
        public Double Bit { get; set; }

        [DataMember(Name = "ask")]
        public Double Ask { get; set; }

        [DataMember(Name = "spot")]
        public Double Spot { get; set; }
    }
}
