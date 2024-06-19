using System;
using static System.Console;

namespace overloading
{
    class Program
    {
        //void Increment(int x)
        //{
        //    x++;
        //    WriteLine("Inside method: " + x); // x is incremented
           
        //}
        //void Increment(ref int x)
        //{
        //    x++;
        //    Console.WriteLine("Inside method: " + x); // x is incremented
        //}


        void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }

        static void Main(string[] args)
        {

            int dividend = 10;
            int divisor = 3;
            int resultQuotient, resultRemainder;

            Program Div = new Program();
            Div.Divide(dividend, divisor, out resultQuotient, out resultRemainder);
            Console.WriteLine("Quotient: " + resultQuotient); // 3
            Console.WriteLine("Remainder: " + resultRemainder); // 1
            Read();






            //Program prg = new Program();
            //int num = 5;


            //------------------Passing num by reference---------------------------
            //prg.Increment(ref num); // Passing num by reference
            //Console.WriteLine("Outside method: " + num); // num is now incremented to 6


            // -----------------Passing num by value-----------------------------
            //prg.Increment(num); // Passing num by value
            //WriteLine("Outside method: " + num); // num remains unchanged (still 5)



        }
    }
}
