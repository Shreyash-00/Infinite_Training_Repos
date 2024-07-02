
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public float Salary { get; set; }

    public Employee(int empId, string empName, float salary)
    {
        EmpId = empId;
        EmpName = empName;
        Salary = salary;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Employee ID: {EmpId}");
        Console.WriteLine($"Employee Name: {EmpName}");
        Console.WriteLine($"Salary: {Salary}");
    }
}

public class ParttimeEmployee : Employee
{
    public float Wages { get; set; }

    public ParttimeEmployee(int empId, string empName, float salary, float wages)
        : base(empId, empName, salary)
    {
        Wages = wages;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Wages: {Wages}");
    }
}


public class Employee_Details
{
    public static void details()
    {
        Console.WriteLine("Enter details for Full-time Employee:");
        Console.Write("Employee ID: ");
        int empId = int.Parse(Console.ReadLine());
        Console.Write("Employee Name: ");
        string empName = Console.ReadLine();
        Console.Write("Salary: ");
        float salary = float.Parse(Console.ReadLine());

        Employee fullTimeEmployee = new Employee(empId, empName, salary);

        Console.WriteLine("\nEnter details for Part-time Employee:");
        Console.Write("Employee ID: ");
        empId = int.Parse(Console.ReadLine());
        Console.Write("Employee Name: ");
        empName = Console.ReadLine();
        Console.Write("Salary: ");
        salary = float.Parse(Console.ReadLine());
        Console.Write("Wages: ");
        float wages = float.Parse(Console.ReadLine());

        ParttimeEmployee partTimeEmployee = new ParttimeEmployee(empId, empName, salary, wages);

        Console.WriteLine("\nFull-time Employee Details:");
        fullTimeEmployee.Display();

        Console.WriteLine("\nPart-time Employee Details:");
        partTimeEmployee.Display();

    }
}
