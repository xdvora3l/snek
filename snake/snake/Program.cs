using System;
using System.Collections.Generic;
using snake;
using static System.Formats.Asn1.AsnWriter;

namespace Snake
{
    class Game
    {
        static int game_Width = 32;
        static int game_Height = 16;
        static void Main(string[] args)
        {

            int score = 5;
            int gameOver = 0;
            int yMove = 0;
            int xMove = 1;

            List<Pixel> tail = new List<Pixel>();

            Pixel head = new Pixel(game_Width / 2, game_Height / 2);
            head.displayColor = ConsoleColor.Red;

            Pixel newTail;

            Berry berry = new Berry();

            Console.WindowHeight = game_Height;
            Console.WindowWidth = game_Width;

            string movement = "RIGHT";

            // used for Delay
            DateTime lastInputTime = DateTime.Now;
            DateTime curentTime = DateTime.Now;
            string buttonPressed = "no";

            while (true)
            {

                Console.Clear();
                if (head.X == game_Width - 1 || head.X == 0 || head.Y == game_Height - 1 || head.Y == 0)
                {
                    gameOver = 1;
                }
                Game.printBoard();

                
                if (berry.X == head.X && berry.Y == head.Y)
                {
                    score++;
                    berry.MoveBerry();

                }
                for (int i = 0; i < tail.Count(); i++)
                {
                    Console.SetCursorPosition(tail[i].X, tail[i].Y);
                    Console.Write("■");
                    if (tail[i].X == head.X && tail[i].Y == head.Y)
                    {
                        gameOver = 1;
                    }
                }
                if (gameOver == 1)
                {
                    break;
                }

                head.printPixel();
                berry.printPixel();

                lastInputTime = DateTime.Now;
                buttonPressed = "no";
                while (true)
                {
                    curentTime = DateTime.Now;
                    if (curentTime.Subtract(lastInputTime).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo playerInput = Console.ReadKey(true);
                        if (playerInput.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonPressed == "no")
                        {
                            movement = "UP";
                            yMove = -1;
                            xMove = 0;
                            buttonPressed = "yes";
                        }
                        if (playerInput.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonPressed == "no")
                        {
                            movement = "DOWN";
                            yMove = 1;
                            xMove = 0;
                            buttonPressed = "yes";
                        }
                        if (playerInput.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonPressed == "no")
                        {
                            movement = "LEFT";
                            xMove = -1;
                            yMove = 0;
                            buttonPressed = "yes";
                        }
                        if (playerInput.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonPressed == "no")
                        {
                            movement = "RIGHT";
                            xMove = 1;
                            yMove = 0;
                            buttonPressed = "yes";
                        }
                    }
                }
                newTail = new Pixel(head.X, head.Y);
                tail.Add(newTail);

                
                if(movement != "")
                {
                    head.X += xMove;
                    head.Y += yMove;
                }

                if (tail.Count() > score)
                {
                    tail.RemoveAt(0);
                }
            }
            printScore(score);
        }

        static void printBoard()
        {
            for (int i = 0; i < game_Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }
            for (int i = 0; i < game_Width; i++)
            {
                Console.SetCursorPosition(i, game_Height - 1);
                Console.Write("■");
            }
            for (int i = 0; i < game_Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }
            for (int i = 0; i < game_Height; i++)
            {
                Console.SetCursorPosition(game_Width - 1, i);
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void printScore(int score)
        {
            Console.SetCursorPosition(game_Width / 5, game_Height / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(game_Width / 5, game_Height / 2 + 1);
        }

        
    }

    

    
}