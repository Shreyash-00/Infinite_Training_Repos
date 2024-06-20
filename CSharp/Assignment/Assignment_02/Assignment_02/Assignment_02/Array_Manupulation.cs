using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Array_Manupulation
    {
        public static void Array_Avg()
        {
            int[] array = { 3, 9, 4, 1, 7, 2, 8, 5, 6 };

            double average = CalculateAverage(array);
            Console.WriteLine($"Average value of array elements: {average}");

            
            int minimum = FindMinimum(array);
            int maximum = FindMaximum(array);
            Console.WriteLine($"Minimum value in the array: {minimum}");
            Console.WriteLine($"Maximum value in the array: {maximum}");
        }
        static double CalculateAverage(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }

            return sum / array.Length;
        }

   
        static int FindMinimum(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        
        static int FindMaximum(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }
    }
}
