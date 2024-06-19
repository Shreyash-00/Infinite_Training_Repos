using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

    class CheckLargest_01
    {
        public static void FindLargestNum()
        {
            WriteLine("Enter the first Number:");
            int num1 = int.Parse(ReadLine());

            WriteLine("Enter the second Number:");
            int num2 = int.Parse(ReadLine());

            WriteLine("Enter the third Number:");
            int num3 = int.Parse(ReadLine());

            int largest = Math.Max(num1, Math.Max(num2, num3));

            WriteLine("The largest number is: " + largest);
            ReadLine();
        }
    }
