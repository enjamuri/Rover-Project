using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASARover
{
    public class Rover
    {
        int xMax;
        int yMax;
        int xPosition;
        int yPosition;
        char direction;
        String movementPlan;
        char roverPresentDirection;
       
        //initializing variables through constructor
        public Rover(int xMax,int yMax,int xCoordinate, int yCoordinate, char direction, string movementPlan)
        {
            
            this.xPosition = xCoordinate;
            this.yPosition = yCoordinate;
            this.direction = direction;
            this.movementPlan = movementPlan;
            this.xMax = xMax;
            this.yMax = yMax;
            this.roverPresentDirection = direction;
            if(xPosition>=xMax || yPosition>=yMax)
            {
                throw new InvalidDataException("Invalid X or Y coordinate");
            }
            if(!(direction=='N'||direction=='S'||direction=='E'||direction=='W')) 
            {
                throw new InvalidDataException();
            }
           
        }
        public void GetFinalDestination( ref int xFinal,ref int yFinal,ref char finalDestination)
        {
             xFinal= xPosition;
            yFinal = yPosition;
            finalDestination = roverPresentDirection; 

        }

        //moving the rover using movement plan expect format ex:LMLMLMMM
        public Boolean MoveRoverToDestination()
        {
            Boolean flag = true;
            char[] ch = movementPlan.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                char move = ch[i];

                //bool flag = true;
                switch (move)
                {
                    case 'L':
                        //calling the roverleftmove method and assiging the returned direction to roverpresentDirection
                        roverPresentDirection = roverLeftMove(roverPresentDirection);
                        
                        break;
                    case 'R':
                        roverPresentDirection = roverRightMove(roverPresentDirection);
                       
                        break;
                    case 'M':
                        flag = RoverMove();
                        break;
                    default:
                        Console.WriteLine("Illegal operation");
                        flag = false;
                        break;
                }
                if (!flag)
                {
                    //x or y coordinate met the minimum size caannot move further
                    Console.WriteLine("Error cannot move further");
                    break;
                }

            }
            return flag;
        }
        private bool RoverMove()
        {
            // if movement plan has M, rover moves forward in one step and direction will not change 
            // ex: 1 3 N   y axis moves one step roverposition is 1 4 N
            Boolean flag = true;
            switch (roverPresentDirection)
            {
                case 'N': //(x,y+1)
                    if (yPosition < yMax)
                    { yPosition++; }
                    else
                    {
                        flag = false;
                    }
                    break;
                case 'S'://(x,y-1)
                    if (yPosition > 0)
                    { yPosition--; }
                    else
                    {
                        flag = false;
                    }
                    break;
                case 'E'://(x+1,y)
                    if (xPosition < xMax) 
                    { xPosition++; }
                    else
                    {
                        flag = false;
                    }
                    break;
                case 'W'://(x-1,y)
                    if (xPosition > 0)
                    {
                        xPosition--;
                    }
                    else
                    {
                        flag = false;
                    }
                    break;
            }
            //Console.WriteLine("After Movement RoverPosition :"+x + " " + y + " " + presentdirection);
            return flag;
        }
        private char roverLeftMove(char dt) //moving rover direction if it 'L'
        {
            //move 90 degree left N->W->S->E->N
            if (dt == 'N')
            {
                dt = 'W';
            }
            else if (dt == 'W')
            {
                dt = 'S';
            }
            else if (dt == 'S')
            {
                dt = 'E';
            }
            else if (dt == 'E')
            {
                dt = 'N';
            }
            return dt;
        }
        private char roverRightMove(char dt) //moving rover if its 'R'
        {
            //Move 90 degrees right N->E->S->W->N
            if (dt == 'N')
            {
                dt = 'E';
            }
            else if (dt == 'W')
            {
                dt = 'N';
            }
            else if (dt == 'S')
            {
                dt = 'W';
            }
            else if (dt == 'E')
            {
                dt = 'S';
            }
            return dt;
        }

       
        public void PrintPosition()
        {
           
            Console.WriteLine("\nCurrent Position of rover is: " + xPosition + " " + yPosition + " " + roverPresentDirection);

        }

    }

}
