using System;

namespace Providers
{
    public interface ITransaction
    {
        Models.ITransaction GetTransaction(String Id);
    }
}
