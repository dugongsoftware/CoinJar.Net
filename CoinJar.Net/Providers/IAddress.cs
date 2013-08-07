using System;
using System.Collections.Generic;

namespace Providers
{
    public interface IAddress
    {
        Models.IAddress GetAddress(String bitcoinAddress);
        IList<Models.IAddress> GetAddresses();
        Models.IAddress CreateAddress(String label);
    }
}