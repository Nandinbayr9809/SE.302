using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Biedaalt
{
    class Program
    {
        public static int HEIGHT = 10, WIDTH = 20;
        //public const int WALL = 1, EMPTY = 0;
        public static char[,] map = new char[HEIGHT, WIDTH];
        public static int speed = 300;
        public static int[] a = new int[2];

        static void Main(string[] args)
        {
            int ballX = WIDTH, ballY = HEIGHT;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i == 0 || j == 0 || i == HEIGHT - 1 || j == WIDTH - 1)
                    {
                        map[i, j] = '1';// 1 - saad, hana
                    }/*
                    else if (i == 3) {
                        map[i,3] = '2';
                    }*/
                    else
                        map[i, j] = ' ';
                }

            }
            speed = 100;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            int x = WIDTH / 2, y = HEIGHT - 2, x0 = WIDTH / 2, y0 = HEIGHT - 2, b_x = 1, b_y = 1, b_x0 = 1, b_y0 = 1;
            Console.CursorVisible = false;
            int[] move = new int[2];
            move[0] = 1;
            move[1] = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("   ");
            Console.SetCursorPosition(x, y);
            Console.Write("22");
            while (true)
            {
                move = bump(move, map, b_x, b_y);

                Console.SetCursorPosition(b_x0, b_y0);
                Console.Write(' ');

                b_x = b_x + move[0];
                b_y += move[1];
                Console.SetCursorPosition(b_x, b_y);
                Console.Write('$');


                /*  if (Console.KeyAvailable)
                  {
                      ConsoleKeyInfo key = Console.ReadKey();
                      switch (key.Key)
                      {
                          case ConsoleKey.LeftArrow:
                              x = x - 1;
                            
                              break;
                          case ConsoleKey.RightArrow:
                              x = x + 1;
                            
                              break;
                          case ConsoleKey.Escape:
                              //Console.Clear();
                              Console.WriteLine("Game over");
                           
                              break;
                      }
                      */
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key.Equals(ConsoleKey.LeftArrow))
                    {
                        x = x - 1;
                    }
                    if (key.Key.Equals(ConsoleKey.RightArrow))
                    {
                        x = x + 1;
                    }
                }

                //Thread.Sleep(10);
                if (x < WIDTH - 4 && x > 0)
                {
                    Console.SetCursorPosition(x0, y0);
                    Console.Write("  ");
                    Console.SetCursorPosition(x, y);
                    Console.Write("22");
                }

                x0 = x; y0 = y;

                b_x0 = b_x;
                b_y0 = b_y;
                //}
                Thread.Sleep(200);
                /* if (b_x > HEIGHT - 3)
                 {
                     b_x = 0;
                     b_y = 0;
                 }*/
            }
        }
        public static int[] bump(int[] move, char[,] map, int posX, int posY)
        {
            if (map[posY, posX + move[0]] != ' ')
            {
                //map = checkBump(map, posX + move[0], posY);
                move[0] = -1 * move[0];
                if (map[posY + move[1], posX] != ' ')
                {
                    //map = checkBump(map, posX, posY + move[1]);
                    move[1] = -1 * move[1];
                }
            }
            if (map[posY + move[1], posX] != ' ')
            {
                //map = checkBump(map, posX, posY + move[1]);
                move[1] = -1 * move[1];
                if (map[posY, posX + move[0]] != ' ')
                {
                    // map = checkBump(map, posX + move[0], posY);
                    move[1] = -1 * move[1];
                }
            }
            return move;

        }
        static char[,] checkBump(char[,] map, int posX, int posY)
        {
            if (map[posY, posX] == '=')
            {
                map[posY, posX] = ' ';
                return map;
            }
            else
            {
                return map;
            }
        }

    }
}