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
            Console.WriteLine("length of Array :");
            string str = Console.ReadLine();
            int Arr_Size = Convert.ToInt32(str);
            int[] array = new int[Arr_Size];
            
            for(int i = 0; i < Arr_Size; i++)
            {
                Console.WriteLine($"Write the {i}th member of array :");
                array[i]= Convert.ToInt32(Console.ReadLine());
                
            }

            for (int i = 0; i < Arr_Size; i++)
            {

                Console.WriteLine($"{array[i]}"); 

            }
            //int[] array = { 3, 9, 4, 1, 7, 2, 8, 5, 6 };

            double average = CalculateAverage(array);
            Console.WriteLine($"Average value of array elements: {average}");


            int minimum = FindMinimum(array);
            int maximum = FindMaximum(array);
            Console.WriteLine($"Minimum value in the array: {minimum}");
            Console.WriteLine($"Maximum value in the array: {maximum}");
        }
        static double CalculateAverage(int[] array)
        {
            double avg;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = array[i] + sum;
            }
            avg = sum / array.Length;
            return avg;
        }


        static int FindMinimum(int[] array)
        {
            int minValue = int.MaxValue;

            // Iterate through the array to find the minimum value
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            // Return the minimum value found
            return minValue;

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
