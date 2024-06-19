using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
class Multiplication_02
{
    public static void Multiplication()
    {

        WriteLine("Enter the number:");
        int number = int.Parse(ReadLine());


        WriteLine($"Multiplication table for {number}:");
        for (int i = 0; i <= 10; i++)
        {
            int result = number * i;
            WriteLine($"{number} * {i} = {result}");

        }
        ReadLine();
    }
}
