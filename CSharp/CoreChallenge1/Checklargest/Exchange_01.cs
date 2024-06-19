using System;
using static System.Console;

class Exchange_01
{
    public static void ExchangeChar()
    {
        WriteLine("Enter a Name:");
        string name = ReadLine();
     
       
        char firstChar = name[0];
        char lastChar = name[name.Length - 1];

        string newName = lastChar + name.Substring(1, name.Length - 2) + firstChar;
        WriteLine("New Name: " + newName);
        ReadLine();

    }
}
