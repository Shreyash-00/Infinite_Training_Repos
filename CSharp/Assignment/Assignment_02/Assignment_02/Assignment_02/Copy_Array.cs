using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Copy_Array
    {
        public static void Array_Copy()
        {
        
            int[] sourceArray = { 1, 2, 3, 4, 5 };

          
            int[] destinationArray = new int[sourceArray.Length];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                destinationArray[i] = sourceArray[i];
            }

            Console.WriteLine("Elements copied from sourceArray to destinationArray:");
            foreach (int num in destinationArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

    }
}
