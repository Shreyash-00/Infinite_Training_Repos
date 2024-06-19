using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    class Swap_Num
    {
        public static void Swap_Number()
        {
            Console.Write("Enter the first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nBefore swapping: number1 = {number1}, number2 = {number2}");

            int temp = number1;
            number1 = number2;
            number2 = temp;

            Console.WriteLine($"After swapping: number1 = {number1}, number2 = {number2}");
        }
    }
}
