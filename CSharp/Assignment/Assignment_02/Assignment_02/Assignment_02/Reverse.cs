using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Reverse
    {
       public static void Reverse_word()
        {
            
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            string reversedWord = ReverseString(word);

            
            Console.WriteLine($"Reverse of the word '{word}' is: {reversedWord}");
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
