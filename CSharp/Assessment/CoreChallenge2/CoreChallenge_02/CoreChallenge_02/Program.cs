using System;
using static System.Console;

namespace CoreChallenge_02
{
   
    public class Product
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }

        public Product(int productId, string productName, int price)
        {
            Product_Id = productId;
            Product_Name = productName;
            Price = price;
        }

        public override string ToString()
        {
            return $"ProductId: {Product_Id}, ProductName: {Product_Name}, Price: {Price}";
        }
    }

  
    public abstract class Student
    {
        public string Name { get; set; }
        public int Student_Id { get; set; }
        public double Marks { get; set; }

        public Student(string name, int studentId, double marks)
        {
            Name = name;
            Student_Id = studentId;
            Marks = marks;
        }

        public abstract bool IsPassed(double marks);
    }

    public class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double marks)
            : base(name, studentId, marks)
        {
        }

        public override bool IsPassed(double marks)
        {
            return marks > 70.0;
        }
    }

    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double marks)
            : base(name, studentId, marks)
        {
        }

        public override bool IsPassed(double marks)
        {
            return marks > 80.0;
        }
    }


    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
            : base("Number cannot be negative.")
        {
        }
    }

  
    public class TestStudent
    {
        public static void Main(string[] args)
        {
            
            WriteLine("Enter name of undergraduate student:");
            string undergradName = ReadLine();

            WriteLine("Enter student ID of undergradate student:");
            int undergradId = int.Parse(ReadLine());

            WriteLine("Enter marks of undergradate student:");
            double undergradMarks = double.Parse(ReadLine());

            Undergraduate undergrad = new Undergraduate(undergradName, undergradId, undergradMarks);

            WriteLine($"{undergrad.Name} passed: {undergrad.IsPassed(undergrad.Marks)}");
            WriteLine("-------------------------------------------Result End------------------------------------------");

            WriteLine("Enter name of graduate student:");
            string gradName = ReadLine();

            WriteLine("Enter student ID of graduate student:");
            int gradId = int.Parse(ReadLine());

            WriteLine("Enter marks of graduate student:");
            double gradMarks = double.Parse(ReadLine());

            Graduate grad = new Graduate(gradName, gradId, gradMarks);

            WriteLine($"{grad.Name} passed: {grad.IsPassed(grad.Marks)}");
            WriteLine("-------------------------------Result End------------------------------------------");

            ReadLine();
            

            
            Product[] products = new Product[10];

           
            //for (int i = 0; i < 10; i++)
            //{
            //    WriteLine($"Enter details for Product {i + 1}:");

            //    Write("Product ID: ");
            //    int productId = int.Parse(ReadLine());

            //    Write("Product Name: ");
            //    string productName = ReadLine();

            //    Write("Price: ");
            //    int price = int.Parse(ReadLine());

            //    products[i] = new Product(productId, productName, price);
            //}

            
            //for (int i = 0; i < products.Length - 1; i++)
            //{
            //    int minIndex = i;
            //    for (int j = i + 1; j < products.Length; j++)
            //    {
            //        if (products[j].Price < products[minIndex].Price)
            //        {
            //            minIndex = j;
            //        }
            //    }

            //    Product temp = products[minIndex];
            //    products[minIndex] = products[i];
            //    products[i] = temp;
            //}

            //WriteLine("\nProducts Sorted by Price:");
            //foreach (var product in products)
            //{
            //    WriteLine(product);
            //}

        
            try
            {
                Write("\nEnter a number: ");
                int number = int.Parse(ReadLine());

                CheckPositiveNumber(number);

                WriteLine("Number is valid.");
            }
            catch (NegativeNumberException ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                WriteLine("Invalid input. Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }

            ReadLine();
        }

        static void CheckPositiveNumber(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException();
            }
        }
    }
}
