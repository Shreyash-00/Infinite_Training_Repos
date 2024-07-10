using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Marks { get; set; }

    public Student(string name, int age, double marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Abhishek Kumar", 22, 73.33333),
            new Student("Abhishek Lomte", 16, 53.33333),
            new Student("Adikeshava", 20, 66.66667),
            new Student("Aman Ullah", 21, 70),
            new Student("Anitha Gayatri", 16, 53.33333),
            new Student("Ayesha Muskan", 22, 73.33333),
            new Student("Bindu", 18, 60),
            new Student("Eswar Sai", 16, 53.33333),
            new Student("Gurukiran Patrimath", 21, 70),
            new Student("Hamsa Ramesh", 21, 70),
            new Student("Jahnavi Ogety", 20, 66.66667),
            new Student("Kajal Shukla", 22, 73.33333),
            new Student("Naman Kudesia", 23, 76.66667),
            new Student("Nithin Jagadeesh", 20, 66.66667),
            new Student("Uhalatha", 18, 60),
            new Student("Pooja Kulkarni", 15, 50),
            new Student("Pretheeba Udhayakumar", 24, 80),
            new Student("Raghav Garg", 23, 76.66667),
            new Student("Raghuram Reddy", 19, 63.33333),
            new Student("Raviteja Booraga", 15, 50),
            new Student("Ritesh Pampanaboyina", 17, 56.66667),
            new Student("Saajana", 18, 60),
            new Student("Sahana Navali", 18, 60),
            new Student("Saishashank Petkar", 24, 80),
            new Student("Saivardhan Manikonda", 20, 66.66667),
            new Student("Santhosh Kenchanagoudar", 23, 76.66667),
            new Student("Shivaraj Patil", 22, 73.33333),
            new Student("Shreyash Srivastava", 21, 70),
            new Student("Siddartha Nainala", 20, 66.66667),
            new Student("Sripriya Ragunath", 22, 73.33333),
            new Student("Swapna", 23, 76.66667),
            new Student("Tanmayee Jollu", 20, 66.66667),
            new Student("Vaishnavi", 21, 70),
            new Student("Vijendra", 15, 50)
        };

        string myName = "Shreyash Srivastava";
        double myMarks = students.First(s => s.Name == myName).Marks;

        var studentsWithHigherMarks = students.Where(s => s.Marks > myMarks);

        Console.WriteLine($"Students who scored higher than {myName}:");
        foreach (var student in studentsWithHigherMarks)
        {
            Console.WriteLine($"{student.Name} - Marks: {student.Marks}");
        }
        Console.Read();
    }
}
