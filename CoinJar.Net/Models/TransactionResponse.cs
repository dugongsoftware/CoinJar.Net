using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class TransactionResponse
    {
        [DataMember(Name = "transaction")]
        public Transaction Transaction { get; set; }
    }
}
