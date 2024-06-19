using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
class Program
{
    static void Main()
    {
        WriteLine("Enter a Name:");
        string Name = ReadLine();

        
        string Newname = ExchangeChar(Name);
        WriteLine("New Name: " + Newname);

        ReadLine();
    }

    
    static string ExchangeChar(string Name)
    {
   
        char firstChar = Name[0];
        char lastChar = Name[Name.Length - 1];

       
        string Newname = lastChar + Name.Substring(1, Name.Length - 2) + firstChar;

        return Newname;
    }
}
