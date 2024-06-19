using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    class Perform_Operations
    {
        public static void Operations()
        {
            Console.Write("Enter the first number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            double addition = number1 + number2;
            double subtraction = number1 - number2;
            double multiplication = number1 * number2;
            double division = number1 / number2;
            

            Console.WriteLine("Results:");
            Console.WriteLine($"Addition: {number1} + {number2} = {addition}");
            Console.WriteLine($"Subtraction: {number1} - {number2} = {subtraction}");
            Console.WriteLine($"Multiplication: {number1} * {number2} = {multiplication}");
            Console.WriteLine($"Division: {number1} / {number2} = {division}");

        }
    }
}
