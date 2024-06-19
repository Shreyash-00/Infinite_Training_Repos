using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    class Check_equal
    {
        public static void Check()
        {
            Console.WriteLine("Enter First Number :");

            int First = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Second Number :");
            int Second = Convert.ToInt32(Console.ReadLine());

            if (First == Second)
            {
                Console.WriteLine("Both are equal");
            }
            else
                Console.WriteLine("Both are not Equal");

        }
    }
}
