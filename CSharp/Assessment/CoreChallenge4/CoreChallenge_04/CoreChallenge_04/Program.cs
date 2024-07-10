using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;
class Program
{
    static List<Employee> empList;

    static void Main()
    {
        try
        {
            // Program 1: Append Text to a File
            AppendTextToFile();

            // Program 2: Calculator Application
            RunCalculator();

            // Program 3: Employee Management System with LINQ Queries
            RunEmployeeManagementSystem();
        }
        catch (Exception ex)
        {
            WriteLine($"Error: {ex.Message}");
        }

        WriteLine("Press any key to exit...");
        ReadKey();
    }

    // Program 1: Append Text to a File
    static void AppendTextToFile()
    {
        Console.WriteLine("--------------- Program 1: Append Text to a File ---------------");

        string directoryPath = @"D:\Infinite_training\Training_Repo\CSharp\Assessment\CoreChallenge4";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string filePath = Path.Combine(directoryPath, "DemoTest.txt");

        Console.WriteLine("Enter the text to append:");
        string textToAppend = Console.ReadLine() + "\n"; // Read user input and append a newline

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(textToAppend);
            }

            Console.WriteLine("Text appended to the file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending text to file: {ex.Message}");
        }

        Console.WriteLine("--------------------------------------------------------------");

    }

    // Program 2: Calculator Application
    static void RunCalculator()
    {
        WriteLine("--------------- Program 2: Calculator Application ---------------");

        WriteLine("Welcome to Calculator Application!");

        while (true)
        {
            try
            {
                
                WriteLine("\nChoose an operation:");
                WriteLine("1. Addition");
                WriteLine("2. Subtraction");
                WriteLine("3. Multiplication");
                WriteLine("4. Exit");

                Write("Enter your choice (1-4): ");
                int choice = int.Parse(ReadLine());

                if (choice == 4)
                {
                    WriteLine("Exiting the program...");
                    break;
                }

               
                Write("Enter first number: ");
                int num1 = int.Parse(ReadLine());
                Write("Enter second number: ");
                int num2 = int.Parse(ReadLine());

              
                Func<int, int, int> operation = null;
                string operationName = "";

                switch (choice)
                {
                    case 1:
                        operation = Calculator.Add;
                        operationName = "Addition";
                        break;
                    case 2:
                        operation = Calculator.Subtract;
                        operationName = "Subtraction";
                        break;
                    case 3:
                        operation = Calculator.Multiply;
                        operationName = "Multiplication";
                        break;
                    default:
                        throw new ArgumentException("Invalid choice. Please enter a number between 1 and 4.");
                }

                
                int result = operation(num1, num2);
                WriteLine($"{operationName} result of {num1} and {num2} is: {result}");
            }
            catch (FormatException)
            {
                WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
        }

        WriteLine("--------------------------------------------------------------");
    }


    static void RunEmployeeManagementSystem()
    {
        WriteLine("--------------- Program 3: Employee Management System ---------------");

        try
        {
          
            InitializeEmployeeList();

            
            while (true)
            {
                WriteLine("\nSelect an option:");
                WriteLine("1. Display detail of all employees");
                WriteLine("2. Display details of employees whose location is not Mumbai");
                WriteLine("3. Display details of employees whose title is AsstManager");
                WriteLine("4. Display details of employees whose Last Name starts with S");
                WriteLine("0. Exit");

                int choice = GetIntInput("Enter your choice");

                switch (choice)
                {
                    case 1:
                        DisplayAllEmployees();
                        break;
                    case 2:
                        DisplayEmployeesNotInMumbai();
                        break;
                    case 3:
                        DisplayAsstManagerEmployees();
                        break;
                    case 4:
                        DisplayEmployeesWithLastNameStartingWithS();
                        break;
                    case 0:
                        WriteLine("Exiting...");
                        return;
                    default:
                        WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error: {ex.Message}");
        }
    }

   
    static void InitializeEmployeeList()
    {
        empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };
    }

    static void DisplayAllEmployees()
    {
        WriteLine("\na. Details of all employees:");
        DisplayEmployeeDetails(empList);
    }

    
    static void DisplayEmployeesNotInMumbai()
    {
        WriteLine("\nb. Details of all employees whose location is not Mumbai:");
        var nonMumbaiEmployees = empList.Where(e => e.City != "Mumbai");
        DisplayEmployeeDetails(nonMumbaiEmployees);
    }

    static void DisplayAsstManagerEmployees()
    {
        WriteLine("\nc. Details of all employees whose title is AsstManager:");
        var asstManagerEmployees = empList.Where(e => e.Title == "AsstManager");
        DisplayEmployeeDetails(asstManagerEmployees);
    }

    static void DisplayEmployeesWithLastNameStartingWithS()
    {
        WriteLine("\nd. Details of all employees whose Last Name starts with S:");
        var lastNameStartsWithS = empList.Where(e => e.LastName.StartsWith("S"));
        DisplayEmployeeDetails(lastNameStartsWithS);
    }


    static void DisplayEmployeeDetails(IEnumerable<Employee> employees)
    {
        foreach (var emp in employees)
        {
            WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}, {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
        }
    }


    static int GetIntInput(string prompt)
    {
        int result;
        while (true)
        {
            Write($"{prompt}: ");
            string input = ReadLine();
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    // Employee class
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    //Calculator class 
    public static class Calculator
    {
        //addition
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        //subtraction
        public static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        //multiplication
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
