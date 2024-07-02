using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Box
{
    public int Length { get; set; }
    public int Breadth { get; set; }

    public Box(int length, int breadth)
    {
        Length = length;
        Breadth = breadth;
    }

    public static Box AddBoxes(Box box1, Box box2)
    {
        int Length2 = box1.Length + box2.Length;
        int Breadth2 = box1.Breadth + box2.Breadth;
        return new Box(Length2, Breadth2);
    }

    public void Display()
    {
        Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
    }
}

public class Test
{
    public static void dimensions_of_box()
    {
        Console.WriteLine("Enter dimensions for Box 1:");
        Console.Write("Length: ");
        int length1 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth1 = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter dimensions for Box 2:");
        Console.Write("Length: ");
        int length2 = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth2 = int.Parse(Console.ReadLine());

        Box box1 = new Box(length1, breadth1);
        Box box2 = new Box(length2, breadth2);

        Console.WriteLine("\nBox 1:");
        box1.Display();

        Console.WriteLine("\nBox 2:");
        box2.Display();

        Box box3 = Box.AddBoxes(box1, box2);

        Console.WriteLine("\nBox 3 (sum of Box 1 and Box 2):");
        box3.Display();


    }
}

