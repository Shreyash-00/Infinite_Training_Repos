using System;

namespace Assignment_05
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public void Display()
        {
            Console.WriteLine($"Book Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine();
        }
    }

    public class BookShelf
    {
        private Book[] books = new Book[5];

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < 5)
                {
                    return books[index];
                }
                return null;
            }
            set
            {
                if (index >= 0 && index < 5)
                {
                    books[index] = value;
                }
            }
        }
    }

    public class Box
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Volume()
        {
            return Length * Width * Height;
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(int id, string name, string department)
        {
            EmployeeId = id;
            Name = name;
            Department = department;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine();
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            StudentId = id;
            Name = name;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();

            // Adding books to the shelf
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter details for book {i + 1}:");
                Console.Write("Book Title: ");
                string title = Console.ReadLine();
                Console.Write("Author Name: ");
                string author = Console.ReadLine();

                shelf[i] = new Book(title, author);
            }

            // Displaying books on the shelf
            Console.WriteLine("\nBooks on the shelf:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Details of book {i + 1}:");
                shelf[i].Display();
            }

            // Example of Box dimensions
            Console.WriteLine("========== DIMENSIONS OF BOX ============");
            Box box = new Box(10, 5, 3);
            Console.WriteLine($"Box Volume: {box.Volume()} cubic units");
            Console.WriteLine();

            // Example of Employee details
            Console.WriteLine("========== EMPLOYEE DETAILS ============");
            Employee emp1 = new Employee(1, "John Doe", "Engineering");
            emp1.DisplayDetails();

            // Example of Student details
            Console.WriteLine("========== STUDENT DETAILS =============");
            Student student1 = new Student(101, "Alice Smith");
            student1.DisplayDetails();

            Console.ReadLine();
        }
    }
}
