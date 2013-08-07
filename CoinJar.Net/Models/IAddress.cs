using System;

namespace Models
{
    public interface IAddress
    {
        string Address { get; set; }
        string Label { get; set; }
        string TotalConfirmed { get; set; }
        string TotalReceived { get; set; }
    }
}
