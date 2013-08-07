using System;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class Transaction : ITransaction
    {
        [DataMember(Name = "confirmations")]
        public object Confirmations { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "reference")]
        public object Reference { get; set; }

        [DataMember(Name = "counterparty_type")]
        public string CounterpartyType { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "uuid")]
        public string Uuid { get; set; }

        [DataMember(Name = "bitcoin_txid")]
        public string BitcoinTxid { get; set; }

        [DataMember(Name = "related_payment_uuid")]
        public string RelatedPaymentUuid { get; set; }

        [DataMember(Name = "counterparty_name")]
        public string CounterpartyName { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
    }
}
