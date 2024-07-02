using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IStudent
{

    int StudentId { get; set; }
    string Name { get; set; }

}

public class Dayscholar : IStudent
{

    public int StudentId { get; set; }
    public string Name { get; set; }
    public string TransportMode { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Transport Mode: {TransportMode}");
    }
}

public class Resident : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string HostelName { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Student ID: {StudentId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Hostel Name: {HostelName}");
    }
}


public class Student
{
    public static void student()
    {

        Console.WriteLine("Enter details for Dayscholar:");
        Console.Write("Student ID: ");
        int dayscholarId = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string dayscholarName = Console.ReadLine();
        Console.Write("Transport Mode: ");
        string transportMode = Console.ReadLine();


        Dayscholar dayscholar = new Dayscholar()
        {
            StudentId = dayscholarId,
            Name = dayscholarName,
            TransportMode = transportMode
        };


        Console.WriteLine("\nEnter details for Resident:");
        Console.Write("Student ID: ");
        int residentId = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string residentName = Console.ReadLine();
        Console.Write("Hostel Name: ");
        string hostelName = Console.ReadLine();


        Resident resident = new Resident()
        {
            StudentId = residentId,
            Name = residentName,
            HostelName = hostelName
        };

        Console.WriteLine("\nDetails of Dayscholar:");
        dayscholar.ShowDetails();

        Console.WriteLine("\nDetails of Resident:");
        resident.ShowDetails();
    }
}