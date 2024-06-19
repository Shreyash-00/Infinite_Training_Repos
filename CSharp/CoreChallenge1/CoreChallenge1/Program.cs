using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace CoreChallenge1
{
    class Program
    {
        static void Main(string[] args)

        {
            

            String Name = "Python";
            int position;
            WriteLine("Enter a position:");
            string userInput = ReadLine();
            position = Convert.ToInt32(userInput);
            string result = Name.Remove(position, 1);
            WriteLine(result);
            ReadLine();
        }
    }
}
