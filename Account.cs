using System;

public class Account
{
    // Properties
    public int AccountNumber { get; }
    public string OwnerName { get; }
    public double Balance { get; private set; }

    // Constants
    private const double MinimumInitialBalance = 1000.0;

    // Constructor
    public Account(int accountNumber, string ownerName, double initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    // Methods
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
        }

        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        Balance -= amount;
    }
}
