using System;

class Program
{
    static void Main(string[] args)
	{
        Console.Write("Enter the first integer: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second integer: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        OddEven(num1, num2);
    }

    public static void OddEven(int a, int b)
    {
        if (a == b)
        {
            Console.WriteLine("Both are Equal");
        }
        else
        {
            Console.WriteLine("Both are not Equal");
        }

        Console.ReadLine();
    }
}
