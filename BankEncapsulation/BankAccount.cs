using System;

namespace BankEncapsulation;

public class BankAccount
{
    private double _balance = 0;

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Console.WriteLine($"Depositing ${amount}");
            _balance += amount;
        }
    }

    public double GetBalance()
    {
        return _balance;
    }
}
