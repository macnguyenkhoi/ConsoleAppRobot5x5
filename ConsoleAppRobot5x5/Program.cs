using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppRobot5x5
{
    internal class Program
    {
        static void Main()
        {
            Robot robotNew = new Robot();

            string command;
            while (robotNew.Face == 0)
            {
                Console.Write("Robot not init yet! Place first:");
                command = Console.ReadLine();
                List<string> tokens = command.Split(',').ToList();
                if (tokens.Count > 2 && tokens[0].Substring(0, 5) == "PLACE")
                    robotNew.Place(int.Parse(tokens[0].Substring(6, 1)), int.Parse(tokens[1]), tokens[2]);
                DrawTable(robotNew.X, robotNew.Y, robotNew.Face);
            }

            while (robotNew.Face != 0)
            {
                command = Console.ReadLine();
                List<string> tokens = command.Split(',').ToList();
                if (tokens.Count>2&&tokens[0].Substring(0, 5) == "PLACE")
                    robotNew.Place(int.Parse(tokens[0].Substring(6, 1)), int.Parse(tokens[1]), tokens[2]);
                if (tokens.Count == 1 && tokens[0] == "MOVE")
                    robotNew.Move();
                if (tokens.Count == 1 && tokens[0] == "RIGHT")
                    robotNew.Right();
                if (tokens.Count == 1 && tokens[0] == "LEFT")
                    robotNew.Left();
                if (tokens.Count == 1 && tokens[0] == "REPORT")
                {
                    Console.Write("X=" + robotNew.X.ToString() + " Y=" + robotNew.Y.ToString() + " FACE:" + Enum.GetName(typeof(Robot.FACING), robotNew.Face));
                    Console.WriteLine();
                }

                DrawTable(robotNew.X, robotNew.Y, robotNew.Face);

            }
            
        }
        
        static void DrawTable(int X, int Y, int FACE)
        {
            const int Horizontal = 5;
            const int Vertical = 5;

            string face = "None";

            switch (FACE)
            {
                case 2:
                    face = "^";
                    break;
                case 4:
                    face = "v";
                    break;
                case 3:
                    face = ">";
                    break;
                case 1:
                    face = "<";
                    break;
            }

            string[][] grid = new string[Vertical][];
            for (int x = 0; x < grid.Length; ++x)
            {
                
                grid[x] = new string[Horizontal];
            }



            
            for (int x = 0; x < grid.Length; ++x)
            {


                
                for (int y = 0; y < grid[x].Length; ++y)
                {

                    if (x == 4 - Y && y == X)
                    {
                        grid[x][y] = face;
                        Console.Write(grid[x][y] + " ");
                    }
                    else
                    {
                        grid[x][y] = "0";
                        Console.Write(grid[x][y] + " ");
                    }

                }
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine();
            

        }

    }



}


public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }

    public int Face { get; set; }

    public enum FACING : int
    {
        WEST = 1, 
        NORTH = 2,
        EAST = 3,
        SOUTH = 4
    }

    public void Move()
    {
        if (this.Face == 1 && X > 0) //WEST
        {
            this.X--; return;
        }
        if (this.Face == 2 && Y < 4)//NORTH
        {
            this.Y++; return;
        }
        if (this.Face == 3 && X < 4)//EAST
        {
            this.X++; return;
        }
        if (this.Face == 4 && Y > 0)//SOUTH
        {
            this.Y--; return;
        }


        Console.Write("Fail off! Do not move.");
        Console.WriteLine();
    }
    public void Right()
    {
        this.Face++;
        if (this.Face > 4)
            this.Face = 1;

    }

    public void Left()
    {
        this.Face--;
        if (this.Face == 0) this.Face = 4;
        }

    public void Place(int X, int Y, string FLACE)
    {
        if (X > -1 && X < 5 && Y > -1 && Y < 5)
        {
            this.X = X; this.Y = Y;
            this.Face = (int)Enum.Parse<FACING>(FLACE);
        }
        else
        {
            Console.Write("Init place not in table. Place again");
            Console.WriteLine();
        }

    }

}

