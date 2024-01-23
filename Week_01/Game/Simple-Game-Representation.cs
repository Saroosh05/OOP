using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using EZInput;


namespace ConsoleApp1
{
    internal class Program
    {

        static int[] ROW = new int[50];  // Array storing rows containing similar enemies
        static int[] COL = new int[50]; // Array storing columns containing similar enemies

        static char[,] board = new char[23,53]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'e', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'e', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'x', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'i', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'P', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        static  void Main(string[] args)
        {
            Console.Clear(); // Clearing Screen
            printBoard(); // Printing Board

            while (true)
            {

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    movePlayerRight(); // Moving Player Right if Right Arrow Key is pressed
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    movePlayerLeft(); // Moving Player Left if Left Arrow Key is pressed
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    fire(); // Creating Fire
                }

                moveFire(1);                    // Moving the fire
                moveEnemy('e', "right");        // Moving enemy 'e' towards right
                moveEnemy('x', "down");         // Moving enemy 'x' downwards
                moveEnemy('i', "diagonal-up");  // Moving enemy 'i' diagonally-up
 
                //Console.Clear();              // Clearing Screen
                printBoard();                   // Printing Board
                Thread.Sleep(100);
            }
        }

        // Function printing the Game Board ///////////////////
        static  void printBoard()                           //
        {                                                  //
            Console.SetCursorPosition(0,0);               //
            for (int row = 0; row < 23; row++)           //
            {                                           //
                for (int col = 0; col < 53; col++)     //
                {                                     //
                    Console.Write(board[row,col]);   //
                }                                   //
                Console.WriteLine();               //
            }                                     //
        }                                        //
        //////////////////////////////////////////


        /////////////////////////// Function moving enemies in different directions ///////////////////////////

        static void moveEnemy(char obj, string direction)
        {
            int index = 0;
            for (int row = 0; row < 23; row++)
            {
                for (int col = 0; col < 53; col++)
                {
                    if (board[row,col] == obj)
                    {
                        ROW[index] = row;   // Storing the row (where obj is found) in the Array
                        COL[index] = col;  // Storing the column (where obj is found) in the Array
                        index++;
                    }
                }
            }

            for (int x = 0; x < index; x++)
            {
                board[ROW[x],COL[x]] = ' ';

                //  If direction is Right
                if (direction == "right")
                {
                    COL[x] = COL[x] + 1;
                    if (COL[x] == 50)
                    {
                        COL[x] = 1;
                    }
                }
                //  If direction is Left
                else if (direction == "left")
                {
                    COL[x] = COL[x] - 1;
                    if (COL[x] == 1)
                    {
                        COL[x] = 50;
                    }
                }
                //  If direction is Up
                else if (direction == "up")
                {
                    ROW[x] = ROW[x] - 1;
                    if (ROW[x] == 1)
                    {
                        ROW[x] = 20;
                    }
                }
                //  If direction is Down
                else if (direction == "down")
                {
                    ROW[x] = ROW[x] + 1;
                    if (ROW[x] == 20)
                    {
                        ROW[x] = 1;
                    }
                }
                //  If direction is Diagonally-Up
                else if (direction == "diagonal-up")
                {
                    COL[x] = COL[x] - 1;
                    ROW[x] = ROW[x] - 1;
                    if (ROW[x] == 1)
                    {
                        ROW[x] = 15;
                        COL[x] = 50;
                    }
                }
                //  If direction is Diagonally-Down
                else if (direction == "diagonal-down")
                {
                    COL[x] = COL[x] + 1;
                    ROW[x] = ROW[x] + 1;
                    if (COL[x] == 50)
                    {
                        COL[x] = 1;
                        ROW[x] = 1;
                    }
                }
                board[ROW[x],COL[x]] = obj;
                Thread.Sleep(10);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////// Funtions For The Player ///////////////////////////////////////////

        // Funtion moving the Player 'P' towards Right
        static void movePlayerRight()
        {
            int Prow = 0;
            int Pcol = 0;
            int index = 0;
            for (int row = 0; row < 23; row++)
            {
                for (int col = 0; col < 53; col++)
                {
                    if (board[row, col] == 'P')
                    {
                        Prow = row;   // Storing the row (where obj is found) in the Array
                        Pcol = col;  // Storing the column (where obj is found) in the Array
                        index++;
                    }
                }
            }
            for (int x = 0; x < index; x++)
            {
                board[Prow, Pcol] = ' ';
                Pcol = Pcol + 1;
                if (Pcol == 50)
                {
                    Pcol = 49;
                }
                board[Prow, Pcol] = 'P';
            }

               
        }

        // Funtion moving the Player 'P' towards Left
        static void movePlayerLeft()
        {
            for (int row = 0; row < 23; row++)
            {
                for (int col = 0; col < 53; col++)
                {
                    if (board[row,col] == 'P')
                    {
                        board[row,col] = ' ';
                        col = col - 1;
                        if (col == 1)
                        {
                            col = 2;
                        }
                        board[row,col] = 'P';
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////// Funtions For Firing Mechanism /////////////////////////////////////

        // Funtion creating the Fire
        static void fire()
        {
            for (int row = 0; row < 23; row++)
            {
                for (int col = 0; col < 53; col++)
                {
                    if (board[row,col] == 'P')
                    {
                        board[row - 1,col] = '*';
                    }
                }
            }


        }

        // Funtion moving the fire
        static void moveFire(int timeStep)
        {
            for (int time = 0; time < timeStep; time++)
            {
                for (int row = 0; row < 23; row++)
                {
                    for (int col = 0; col < 53; col++)
                    {
                        if (board[row,col] == '*')
                        {
                            board[row,col] = ' ';
                            if (row == 1)
                            {
                                break;
                            }
                            board[row - 1,col] = '*';
                        }
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
