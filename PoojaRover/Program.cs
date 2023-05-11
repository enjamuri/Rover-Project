using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace NASARover
{
    internal class Program
    {
        public static char direction;
        public static int xMax;
        public static int yMax;
        public static char roverPresentDirection;
        public static String roverMovementPlan;
        public static int xposition = 0, yposition = 0;
        public static Boolean ReadGraphMaxCoordinates()
        {
            //Reading graph size from the user expected format ex:5 5
            Boolean flag = false;
            Console.WriteLine("Enter Graph Upper Right Coordinate: ");
            string coordinates = Console.ReadLine();
            List<string> list = new List<string>();
            list = coordinates.Split(" ").ToList();
            //checking the list if 2 then assign it to x,y coordinates else return error message
            if (list.Count == 2)
            {
                xMax = int.Parse(list[0]);
                yMax = int.Parse(list[1]);
                Console.WriteLine("X=" + xMax + " " + "Y=" + yMax);
                flag = true;
            }
            else
            {
                //If user enter more than 2 coordinates throw error
                Console.Error.WriteLine("You have entered wrong coordinates!!!\n Please enter only X Y coordinates");
                flag = false;
            }
            return flag;

        }

        public static Boolean ReadStartingPosition()
        {

            //Asking User to enter starting position of rover expecting format ex:1 2 N ->(E/W/S/N)
            Console.WriteLine("Please Enter Starting Position :");
            string startposition = Console.ReadLine();
            List<string> position = new List<string>();

            position = startposition.Split(" ").ToList();
            Boolean flag = false;
            if (position.Count == 3)
            {
                //if list size is 3 then assigning the x,y,direction of the rover
                xposition = int.Parse(position[0]);
                yposition = int.Parse(position[1]);
                if ((xposition > xMax) || (yposition > yMax))
                {
                    //if user entered out of graph size throws an error
                    Console.WriteLine("You have entered out of bound coordinates");
                    flag = false;
                    return flag;
                }
                if (position[2] == "N" || position[2] == "E" || position[2] == "W" || position[2] == "S")
                {
                    direction = char.Parse(position[2]);
                    flag = true;
                    Console.WriteLine("Starting position is: " + xposition + " " + yposition + " " + direction);
                }

                else
                {
                    Console.WriteLine("You have enter unrecognized way ");
                    flag = false;
                    return flag;
                }
            }
            else
            {
                Console.WriteLine("You entered wrong details. Please enter x y (N/S/E/W)");
                flag = false;
                return flag;
            }
            return flag;
        }


        public static void ReadMovementPlan()
        {
            //Movement Plan
            roverPresentDirection = direction;
            Console.WriteLine("Enter the rover movement: ");
            String input = Console.ReadLine();
            roverMovementPlan = input;
        }

        public static void Main(string[] args)
        {
            //Read graph coordinates
            if (!ReadGraphMaxCoordinates())
                return;

            List<Rover> rovers = new List<Rover>();
            //Read all rovers data
            while (true)
            {
                if (!ReadStartingPosition())
                    return;
                ReadMovementPlan();
                //Create rover and add to list
                Rover r1 = new Rover(xMax, yMax, xposition, yposition, direction, roverMovementPlan);
                rovers.Add(r1);

                Console.WriteLine("Do you want to enter another Rover data (Y/N)");
                char response = Console.ReadKey().KeyChar;
                if (response == 'Y')
                {
                    continue;
                }
                else
                {
                    break;
                }

            }

            //Move all rovers one by one
            foreach (Rover rover in rovers)
            {
                rover.MoveRoverToDestination();
                rover.PrintPosition();
            }

        }

    }
}