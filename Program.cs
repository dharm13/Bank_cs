// I used the help of AI to develop this banking console application.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Account> accounts = new List<Account>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. View accounts");
            Console.WriteLine("2. Create an account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewAccounts(accounts);
                    break;
                case "2":
                    CreateAccount(accounts);
                    break;
                case "3":
                    Deposit(accounts);
                    break;
                case "4":
                    Withdraw(accounts);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    static void ViewAccounts(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
        }
        else
        {
            Console.WriteLine("Accounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Owner: {account.OwnerName}, Balance: ${account.Balance}");
            }
        }
    }

    static void CreateAccount(List<Account> accounts)
    {
        Console.Write("Enter owner's name: ");
        string ownerName = Console.ReadLine();

        double initialBalance;
        while (true)
        {
            Console.Write("Enter initial balance (minimum $1000): ");
            if (double.TryParse(Console.ReadLine(), out initialBalance) && initialBalance >= 1000)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number equal to or greater than $1000.");
            }
        }

        Random random = new Random();
        int accountNumber = random.Next(100000, 999999); // Generate a random 6-digit account number

        Account newAccount = new Account(accountNumber, ownerName, initialBalance);
        accounts.Add(newAccount);

        Console.WriteLine($"Account created successfully with Account Number: {newAccount.AccountNumber}, Owner: {newAccount.OwnerName}, Balance: ${newAccount.Balance}");
    }

    static void Deposit(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }

        Console.Write("Enter account number to deposit into: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a valid integer.");
            return;
        }

        Console.Write("Enter deposit amount: ");
        if (!double.TryParse(Console.ReadLine(), out double depositAmount) || depositAmount <= 0)
        {
            Console.WriteLine("Invalid deposit amount. Please enter a valid positive number.");
            return;
        }

        Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
        if (account == null)
        {
            Console.WriteLine($"Account with Account Number {accountNumber} not found.");
            return;
        }

        account.Deposit(depositAmount);
        Console.WriteLine($"Deposit successful. Updated balance for Account Number {account.AccountNumber}: ${account.Balance}");
    }

    static void Withdraw(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }

        Console.Write("Enter account number to withdraw from: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a valid integer.");
            return;
        }

        Console.Write("Enter withdrawal amount: ");
        if (!double.TryParse(Console.ReadLine(), out double withdrawalAmount) || withdrawalAmount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount. Please enter a valid positive number.");
            return;
        }

        Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
        if (account == null)
        {
            Console.WriteLine($"Account with Account Number {accountNumber} not found.");
            return;
        }

        try
        {
            account.Withdraw(withdrawalAmount);
            Console.WriteLine($"Withdrawal successful. Updated balance for Account Number {account.AccountNumber}: ${account.Balance}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Withdrawal failed: {ex.Message}");
        }
    }
}
