using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("program to accept 2 integers and check whether they are equal");
            Check_equal.Check();
            Console.WriteLine("-------------------------------------------------------------------First Program Completed-------------------------------------------------------------------------");


            Console.WriteLine("check whether a given number is positive or negative");
            Postive_Negative.Check_pos_neg();
            Console.WriteLine("-------------------------------------------------------------------Second Program Completed-------------------------------------------------------------------------");


            Console.WriteLine("takes 2 numbers from the user, and then performs (+,/,-,*) on them");
            Perform_Operations.Operations();
            Console.WriteLine("-------------------------------------------------------------------Third Program Completed-------------------------------------------------------------------------");


            Console.WriteLine("C# Sharp program to swap two numbers");
            Swap_Num.Swap_Number();
            Console.WriteLine("-------------------------------------------------------------------Fourth Program Completed-------------------------------------------------------------------------");


            Console.WriteLine("C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation"); 
            Display_Four_Time.Display_01();
            Console.WriteLine("-------------------------------------------------------------------Fifth Program Completed-------------------------------------------------------------------------");


            Console.ReadLine();
        }
    }
}
