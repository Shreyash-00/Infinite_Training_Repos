using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter your first name");
			string Lname = Console.ReadLine();
			Console.WriteLine("Please enter your last name");
			string Rname = Console.ReadLine();
			Console.WriteLine("Your first name is " +Lname+ " and your last name is " + Rname);
			Console.ReadLine();
		}
	}
}
