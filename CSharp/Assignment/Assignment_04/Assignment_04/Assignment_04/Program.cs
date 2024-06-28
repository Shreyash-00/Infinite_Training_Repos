using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
public class Program
{
    public static void Main(string[] args)
    {
        // Program 1: Display First Name and Last Name in Uppercase
        WriteLine("Program 1: Enter your First Name:");
        string firstName = ReadLine();

        WriteLine("Enter your Last Name:");
        string lastName = ReadLine();

        DisplayNamesInUppercase(firstName, lastName);
        WriteLine();

        // Program 2: Count Occurrences of a Letter in a String
        WriteLine("Program 2: Enter a string:");
        string input = ReadLine();

        WriteLine("Enter the letter to count:");
        char letter = ReadLine()[0]; // Read first character as the letter

        int count = CountOccurrences(input, letter);
        WriteLine($"The letter '{letter}' appears {count} times in the string.");
        WriteLine();

        // Program 3: Banking System with Custom Exception Handling
        WriteLine("Program 3: Banking System Example");

        WriteLine("Enter initial balance:");
        double initialBalance = Convert.ToDouble(ReadLine());
        BankingSystem account = new BankingSystem(initialBalance);

        try
        {
            WriteLine($"Initial balance: {account.CheckBalance()}");
            WriteLine("Enter deposit amount:");
            double depositAmount = Convert.ToDouble(ReadLine());
            account.Deposit(depositAmount);

            WriteLine($"Enter withdrawal amount (It will throw Insufficient_Balance_Exception if more than balance):");
            double withdrawalAmount = Convert.ToDouble(ReadLine());
            account.Withdraw(withdrawalAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            WriteLine($"Exception : {ex.Message}");
        }
        WriteLine();

        // Program 4: Scholarship Class with Calculation Based on Marks
        WriteLine("Program 4: Scholarship Calculation Example");

        WriteLine("Enter marks :");
        int marks = Convert.ToInt32(ReadLine());

        WriteLine("Enter fees amount:");
        double fees = Convert.ToDouble(ReadLine());

        Scholarship scholarship = new Scholarship();
        double amount = scholarship.CalculateScholarship(marks, fees);
        WriteLine($"Scholarship amount for marks {marks} is: {amount}");

        ReadLine();
    }

    public static void DisplayNamesInUppercase(string firstName, string lastName)
    {
        WriteLine(firstName.ToUpper());
        WriteLine(lastName.ToUpper());
    }

    public static int CountOccurrences(string input, char letter)
    {
        int count = 0;
        foreach (char c in input)
        {
            if (Char.ToUpper(c) == Char.ToUpper(letter))
            {
                count++;
            }
        }
        return count;
    }
}

public class BankingSystem
{
    private double balance;

    public BankingSystem(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
        WriteLine($"Deposit of {amount} successful. Current balance: {balance}");
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new InsufficientBalanceException();
        }
        else
        {
            balance -= amount;
            WriteLine($"Withdrawal of {amount} successful. Current balance: {balance}");
        }
    }

    public double CheckBalance()
    {
        return balance;
    }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() : base("Insufficient balance in the account.") { }
}

public class Scholarship
{
    public double CalculateScholarship(int marks, double fees)
    {
        double scholarshipAmount = 0;

        if (marks >= 70 && marks <= 80)
        {
            scholarshipAmount = 0.2 * fees; 
        }
        else if (marks > 80 && marks <= 90)
        {
            scholarshipAmount = 0.3 * fees; 
        }
        else if (marks > 90)
        {
            scholarshipAmount = 0.5 * fees; 
        }

        return scholarshipAmount;
    }
}
