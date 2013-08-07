using System;

namespace Models
{
    public interface ITransaction
    {
        string Amount { get; set; }
        string BitcoinTxid { get; set; }
        object Confirmations { get; set; }
        string Status { get; set; }
    }
}
