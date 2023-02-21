using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            char[,] array = {
                { '0', '1', '2' },
                { '3', '4', '5' },
                { '6', '7', '8' }
            };

            Turn(array);
        }

        public static void GameInstructionsPlayer1(char[,] array, int nomerNaPole)
        {
            switch (nomerNaPole)
            {
                case 0:
                    array[0, 0] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 1:
                    array[0, 1] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 2:
                    array[0, 2] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 3:
                    array[1, 0] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 4:
                    array[1, 1] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 5:
                    array[1, 2] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 6:
                    array[2, 0] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 7:
                    array[2, 1] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 8:
                    array[2, 2] = 'x';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
            }
        }

        public static void GameInstructionsPlayer2(char[,] array, int nomerNaPole)
        {
            switch (nomerNaPole)
            {
                case 0:
                    array[0, 0] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 1:
                    array[0, 1] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 2:
                    array[0, 2] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 3:
                    array[1, 0] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 4:
                    array[1, 1] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 5:
                    array[1, 2] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 6:
                    array[2, 0] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 7:
                    array[2, 1] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
                case 8:
                    array[2, 2] = 'o';
                    Console.Clear();
                    Turn(array);
                    GameField(array);
                    break;
            }
        }

        public static void Turn(char[,] array)
        {
            HasWon(array);
            GameField(array);
            int whichPlayer = 1;             
            int nomerNaPole;

            if (whichPlayer % 2 != 0)
            {
                Console.Write("Player 1: ");
                Console.WriteLine(whichPlayer);
                nomerNaPole = int.Parse(Console.ReadLine());
                if (nomerNaPole >= 0 && nomerNaPole <= 8)
                {                 
                    GameInstructionsPlayer1(array, nomerNaPole);
                    whichPlayer++;
                }
                else
                {
                    Console.Write("yok");
                }
            }
            if(whichPlayer % 2 == 0)
            {
                Console.Write("Player 2: ");
                Console.WriteLine("Which player var:{0}",whichPlayer);

                nomerNaPole = int.Parse(Console.ReadLine());
                if (nomerNaPole >= 0 && nomerNaPole <= 8)
                {
                    GameInstructionsPlayer2(array, nomerNaPole);
                    whichPlayer++;
                }
                else
                {
                    Console.WriteLine("yok");
                }
            }           
        }

        public static void HasWon(char[,] array)
        {
            //Horizontal Wins

            if (array[0, 0] == 'x' && array[0, 1] == 'x' && array[0, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[1, 0] == 'x' && array[1, 1] == 'x' && array[1, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[2, 0] == 'x' && array[2, 1] == 'x' && array[2, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            //Vertical Wins
            if (array[0, 0] == 'x' && array[1, 0] == 'x' && array[2, 0] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 1] == 'x' && array[1, 1] == 'x' && array[2, 1] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 2] == 'x' && array[1, 2] == 'x' && array[2, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            //Diagonal Wins
            if (array[0, 0] == 'x' && array[1, 1] == 'x' && array[2, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 0] == 'x' && array[1, 1] == 'x' && array[2, 2] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 2] == 'x' && array[1, 1] == 'x' && array[2, 0] == 'x')
            {
                Console.WriteLine("Player one has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            //Player 2
        }

        public static void GameField(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
