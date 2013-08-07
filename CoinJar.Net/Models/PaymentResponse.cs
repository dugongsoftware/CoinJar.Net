using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class PaymentResponse
    {
        [DataMember(Name = "payment")]
        public Payment Payment { get; set; }
    }
}
