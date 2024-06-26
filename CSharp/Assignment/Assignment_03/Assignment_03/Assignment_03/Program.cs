using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

public class Accounts
{
    private string accountNo;
    private string customerName;
    private string accountType;
    private char transactionType;
    private decimal amount;
    private decimal balance;

    public Accounts(string accountNo, string customerName, string accountType)
    {
        this.accountNo = accountNo;
        this.customerName = customerName;
        this.accountType = accountType;
        this.balance = 2100;
    }

    public void UpdateBalance()
    {
        if (transactionType == 'D')
        {
            Credit(amount);
        }
        else if (transactionType == 'W')
        {
            Debit(amount);
        }
        else
        {
            WriteLine("Invalid transaction type!");
        }
    }

    public void Credit(decimal amount)
    {
        this.balance += amount;
    }

    public void Debit(decimal amount)
    {
        if (balance >= amount)
        {
            this.balance -= amount;
        }
        else
        {
            WriteLine("Insufficient balance!");
        }
    }

    public void ShowData()
    {
        WriteLine("Account Number: " + accountNo);
        WriteLine("Customer Name: " + customerName);
        WriteLine("Account Type: " + accountType);
        WriteLine("Balance: " + balance);
    }

    public decimal Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public char TransactionType
    {
        get { return transactionType; }
        set { transactionType = value; }
    }
}

public class Program
{
    public static void Main()
    {
        // Accounts
        Accounts account1 = new Accounts("10354678", "Shreyash", "Savings");

        account1.TransactionType = 'D';
        account1.Amount = 2200;
        account1.UpdateBalance();
        account1.ShowData();

        account1.TransactionType = 'W';
        account1.Amount = 1500;
        account1.UpdateBalance();
        account1.ShowData();

        WriteLine();

        Read();
    }
}
