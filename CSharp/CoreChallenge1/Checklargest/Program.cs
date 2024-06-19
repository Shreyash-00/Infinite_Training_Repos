using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
class Checklargest
{
    static void Main()
    {
        
        WriteLine("Enter the first Number:");
        int num1 = int.Parse(ReadLine());

       
        WriteLine("Enter the second Number:");
        int num2 = int.Parse(ReadLine());

      
        WriteLine("Enter the third Number:");
        int num3 = int.Parse(ReadLine());

        FindLargest(num1, num2, num3);
    }

    static void FindLargest(int a, int b, int c)
    {
        int largest = Math.Max(a, Math.Max(b, c));

        WriteLine("The largest number is: " + largest);
        ReadLine();
    }
}
