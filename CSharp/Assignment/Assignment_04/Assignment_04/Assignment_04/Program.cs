using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Program 1: Display First Name and Last Name in Uppercase
        Console.WriteLine("Program 1: Enter your First Name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter your Last Name:");
        string lastName = Console.ReadLine();

        DisplayNamesInUppercase(firstName, lastName);
        Console.WriteLine();

        // Program 2: Count Occurrences of a Letter in a String
        Console.WriteLine("Program 2: Enter a string:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the letter to count:");
        char letter = Console.ReadLine()[0]; // Read first character as the letter

        int count = CountOccurrences(input, letter);
        Console.WriteLine($"The letter '{letter}' appears {count} times in the string.");
        Console.WriteLine();

        // Program 3: Banking System with Custom Exception Handling
        Console.WriteLine("Program 3: Banking System Example");

        Console.WriteLine("Enter initial balance:");
        double initialBalance = Convert.ToDouble(Console.ReadLine());
        BankingSystem account = new BankingSystem(initialBalance);

        try
        {
            Console.WriteLine($"Initial balance: {account.CheckBalance()}");
            Console.WriteLine("Enter deposit amount:");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            account.Deposit(depositAmount);

            Console.WriteLine($"Enter withdrawal amount (It will throw Insufficient_Balance_Exception if more than balance):");
            double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
            account.Withdraw(withdrawalAmount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Exception : {ex.Message}");
        }
        Console.WriteLine();

        // Program 4: Scholarship Class with Calculation Based on Marks
        Console.WriteLine("Program 4: Scholarship Calculation Example");

        Console.WriteLine("Enter marks :");
        int marks = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter fees amount:");
        double fees = Convert.ToDouble(Console.ReadLine());

        Scholarship scholarship = new Scholarship();
        double amount = scholarship.CalculateScholarship(marks, fees);
        Console.WriteLine($"Scholarship amount for marks {marks} is: {amount}");

        Console.ReadLine();
    }

    public static void DisplayNamesInUppercase(string firstName, string lastName)
    {
        Console.WriteLine(firstName.ToUpper());
        Console.WriteLine(lastName.ToUpper());
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
        Console.WriteLine($"Deposit of {amount} successful. Current balance: {balance}");
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
            Console.WriteLine($"Withdrawal of {amount} successful. Current balance: {balance}");
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
