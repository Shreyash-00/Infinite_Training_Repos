using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Days
    {
        static string GetDayName(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 7:
                    return "Sunday";
                default:
                    return null;
            }
        }

        public static void Days_week()
        {
            Console.Write("Enter a day number (1-7): ");
            int dayNumber = Convert.ToInt32(Console.ReadLine());

            string dayName = GetDayName(dayNumber);

            if (dayName != null)
            {
                Console.WriteLine($"The day corresponding to {dayNumber} is {dayName}.");
            }
            else
            {
                Console.WriteLine("Invalid day number. Please enter a number between 1 and 7.");
            }
        }
    }
}
