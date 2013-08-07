using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models.CoinJar
{
    [DataContract]
    public class Payment
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "related_transaction")]
        public object RelatedTransaction { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "reference")]
        public object Reference { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "uuid")]
        public string Uuid { get; set; }

        [DataMember(Name = "payee_name")]
        public string PayeeName { get; set; }

        [DataMember(Name = "payee_type")]
        public string PayeeType { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
    }
}
