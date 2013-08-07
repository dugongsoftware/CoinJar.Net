using System;

namespace Providers
{
    public interface IPayment
    {
        String SendPayment(String address, Double amount);
        String SendPayment(String address, Double amount, String label);
        String SendPayment(String address, Double amount, String label, Double fee);
    }
}