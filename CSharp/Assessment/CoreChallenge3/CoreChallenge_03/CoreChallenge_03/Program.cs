using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoreChallenge_03
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("----------------------------IPL Score------------------------------ ");
            WriteLine("Enter the number of matches:");
            int j = 0;
            while (!int.TryParse(ReadLine(), out j) || j <= 0) 
            {
                WriteLine(" Please enter a valid number of matches");
                WriteLine("Enter the number of matches:");
            }

            Cricket cricket = new Cricket();
            cricket.PointsCalculation(j);


            ////////////////////// SECOND PROGRAM INPUT /////////////////////////////
            ///
            WriteLine("----------------------------Box Size------------------------------ ");


            WriteLine("Enter length of Box 1:");
            double length1 = double.Parse(ReadLine());

            WriteLine("Enter breadth of Box 1:");
            double breadth1 = double.Parse(ReadLine());

            WriteLine("Enter length of Box 2:");
            double length2 = double.Parse(ReadLine());

            WriteLine("Enter breadth of Box 2:");
            double breadth2 = double.Parse(ReadLine());

            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);

            
            Box box3 = box1.Add(box2);

         
            WriteLine("Details of Box 3:");
            box3.Display();


            ReadLine(); 
        }

    }


    class Cricket
    {
        public void PointsCalculation(int No_of_Matches)
        {
            int[] scores = new int[No_of_Matches];

  
            for (int i = 0; i < No_of_Matches; i++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Write($"Enter score for match {i + 1}: ");
                    if (int.TryParse(ReadLine(), out int score) && score >= 0)
                    {
                        scores[i] = score;
                        validInput = true;
                    }
                    else
                    {
                        WriteLine("Please enter a valid score.");
                    }
                }
            }

           
            int sum = 0;
            for (int i = 0; i < No_of_Matches; i++)
            {
                sum += scores[i];
            }

        
            double average = (double)sum / No_of_Matches;

           
            WriteLine($"Sum of Scores: {sum} Runs");
            WriteLine($"Average Score: {average} Runs");
        }
    }

    //////////////////////////////////////NEW PROGRAM/////////////////////////////////////////



class Box
    {
      
        public double Length;
        public double Breadth;

       
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public Box Add(Box other)
        {
            return new Box(Length + other.Length, Breadth + other.Breadth);
        }

        public void Display()
        {
            WriteLine($"Box :- Length: {Length} meter, Breadth: {Breadth} meter");
        }
    }

}


