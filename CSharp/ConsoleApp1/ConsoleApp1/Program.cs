using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter your name:");
			string name = Console.ReadLine();

			Console.WriteLine("Please enter your age:");
			int age = int.Parse(Console.ReadLine());

			Console.WriteLine("Your name is " + name + "! You are " + age + " years old.");
			Console.ReadLine();
		}
	}
}
