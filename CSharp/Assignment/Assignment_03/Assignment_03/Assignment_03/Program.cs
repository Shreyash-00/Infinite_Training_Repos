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
        this.balance = 0;
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

public class Student
{
    private int rollNo;
    private string name;
    private string className;
    private string semester;
    private string branch;
    private int[] marks = new int[5];

    public Student(int rollNo, string name, string className, string semester, string branch)
    {
        this.rollNo = rollNo;
        this.name = name;
        this.className = className;
        this.semester = semester;
        this.branch = branch;
    }

    public void GetMarks(int[] marks)
    {
        if (marks.Length != 5)
        {
            WriteLine("Error: Please provide marks for all 5 subjects.");
            return;
        }

        this.marks = marks;
    }

    public void DisplayResult()
    {
        double average = CalculateAverage();

        bool passed = CheckPassFail();

        WriteLine("Roll Number: " + rollNo);
        WriteLine("Name: " + name);
        WriteLine("Class: " + className);
        WriteLine("Semester: " + semester);
        WriteLine("Branch: " + branch);
        WriteLine("Marks: " + string.Join(", ", marks));
        WriteLine("Average Marks: " + average);

        if (passed)
        {
            WriteLine("Result: Passed");
        }
        else
        {
            WriteLine("Result: Failed");
        }
    }

    private double CalculateAverage()
    {
        if (marks.Length == 0)
        {
            return 0;
        }

        int sum = 0;
        foreach (int mark in marks)
        {
            sum += mark;
        }

        return (double)sum / marks.Length;
    }

    private bool CheckPassFail()
    {
        bool allSubjectsPassed = true;
        foreach (int mark in marks)
        {
            if (mark < 35)
            {
                allSubjectsPassed = false;
                break;
            }
        }

        double average = CalculateAverage();

        if (!allSubjectsPassed || average < 50)
        {
            return false;
        }

        return true;
    }

    public void DisplayData()
    {
        WriteLine("Student Details:");
        WriteLine("Roll Number: " + rollNo);
        WriteLine("Name: " + name);
        WriteLine("Class: " + className);
        WriteLine("Semester: " + semester);
        WriteLine("Branch: " + branch);
        WriteLine("Marks: " + string.Join(", ", marks));
    }
}

public class Saledetails
{
    private int salesNo;
    private int productNo;
    private decimal price;
    private DateTime dateOfSale;
    private int qty;
    private decimal totalAmount;

    public Saledetails(int salesNo, int productNo, decimal price, int qty, DateTime dateOfSale)
    {
        this.salesNo = salesNo;
        this.productNo = productNo;
        this.price = price;
        this.qty = qty;
        this.dateOfSale = dateOfSale;

        Sales();
    }

    public void Sales()
    {
        totalAmount = qty * price;
    }

    public void ShowData()
    {
        WriteLine("Sales Number: " + salesNo);
        WriteLine("Product Number: " + productNo);
        WriteLine("Price: " + price);
        WriteLine("Quantity: " + qty);
        WriteLine("Date of Sale: " + dateOfSale.ToShortDateString());
        WriteLine("Total Amount: " + totalAmount);
    }
}

public class Customer
{
    private int customerId;
    private string name;
    private int age;
    private string phone;
    private string city;

    public Customer()
    {
    }

    public Customer(int customerId, string name, int age, string phone, string city)
    {
        this.customerId = customerId;
        this.name = name;
        this.age = age;
        this.phone = phone;
        this.city = city;
    }

    public void DisplayCustomer()
    {
        WriteLine("Customer ID: " + customerId);
        WriteLine("Name: " + name);
        WriteLine("Age: " + age);
        WriteLine("Phone: " + phone);
        WriteLine("City: " + city);
    }

    ~Customer()
    {
        WriteLine("Destructor called for Customer " + customerId);
    }
}

public class Program
{
    public static void Main()
    {
        // Accounts example
        Accounts account1 = new Accounts("10354678", "Shreyash", "Savings");

        account1.TransactionType = 'D';
        account1.Amount = 1000;
        account1.UpdateBalance();
        account1.ShowData();

        account1.TransactionType = 'W';
        account1.Amount = 500;
        account1.UpdateBalance();
        account1.ShowData();

        WriteLine();

        // Student example
        Student student1 = new Student(1, "Shreyash Srivastava", "12th", "Semester 1", "Science");

        int[] marks = { 80, 75, 60, 55, 70 };
        student1.GetMarks(marks);

        student1.DisplayData();
        student1.DisplayResult();

        WriteLine();

        // Saledetails example
        Saledetails sale1 = new Saledetails(1, 101, 25.5m, 5, DateTime.Now);

        WriteLine("Sales Details:");
        sale1.ShowData();
        WriteLine();

        // Customer example
        Customer customer1 = new Customer(1001, "Shreyash", 23, "103573834", "Chennai");

        WriteLine("Customer Details:");
        customer1.DisplayCustomer();
        WriteLine();

        // Example of using destructor
        customer1 = null;
        GC.Collect(); // Explicitly calling garbage collector to trigger destructor
        Read();
    }
}
