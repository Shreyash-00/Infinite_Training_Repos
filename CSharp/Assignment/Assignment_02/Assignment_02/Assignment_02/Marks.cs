using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Marks
    {
        public static void Marks_Function()
        {
            int[] marks = new int[10];

            
            Console.WriteLine("Enter ten marks:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

          
            int total = CalculateTotal(marks);
            Console.WriteLine($"Total marks: {total}");

          
            double average = CalculateAverage(marks);
            Console.WriteLine($"Average marks: {average:F2}");

            int minimum = FindMinimum(marks);
            int maximum = FindMaximum(marks);
            Console.WriteLine($"Minimum marks: {minimum}");
            Console.WriteLine($"Maximum marks: {maximum}");

            int[] ascendingOrder = SortAscending(marks);
            Console.WriteLine("Marks in ascending order:");
            DisplayMarks(ascendingOrder);

            int[] descendingOrder = SortDescending(marks);
            Console.WriteLine("Marks in descending order:");
            DisplayMarks(descendingOrder);
        }

  
        static int CalculateTotal(int[] marks)
        {
            int total = 0;
            foreach (int mark in marks)
            {
                total += mark;
            }
            return total;
        }

        
        static double CalculateAverage(int[] marks)
        {
            int total = CalculateTotal(marks);
            return (double)total / marks.Length;
        }

        static int FindMinimum(int[] marks)
        {
            int min = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] < min)
                {
                    min = marks[i];
                }
            }
            return min;
        }

        static int FindMaximum(int[] marks)
        {
            int max = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] > max)
                {
                    max = marks[i];
                }
            }
            return max;
        }

        static int[] SortAscending(int[] marks)
        {
            int[] ascendingOrder = new int[marks.Length];
            Array.Copy(marks, ascendingOrder, marks.Length);
            Array.Sort(ascendingOrder);
            return ascendingOrder;
        }

    
        static int[] SortDescending(int[] marks)
        {
            int[] descendingOrder = new int[marks.Length];
            Array.Copy(marks, descendingOrder, marks.Length);
            Array.Sort(descendingOrder);
            Array.Reverse(descendingOrder);
            return descendingOrder;
        }

        static void DisplayMarks(int[] marks)
        {
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();
        }
    }
}
