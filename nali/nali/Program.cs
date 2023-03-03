using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using nali;
using System.Threading;

namespace nali
{
    public class Program
    {
        public static bool whichPlayer;
        public static bool GameOver = false;

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
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("                                  By Nikola Valkov (trohata)");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Local Multiplayer game");
            Console.WriteLine("2. Online MultiPlayer game");
            Console.WriteLine("3. Exit");
            try
            {
                Console.Write("Input: ");
                byte input = byte.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        TurnLocalMultiplayer(array);
                        break;
                    case 2:
                        ChatTest();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        Console.ReadKey();
                        Console.Clear();
                        StartGame();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, try again");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }

        }
        #region LocalMultiplayerFunctions
        public static void GameInstructionsPlayer1(char[,] array, int nomerNaPole)
        {
            switch (nomerNaPole)
            {
                case 0:
                    array[0, 0] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 1:
                    array[0, 1] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 2:
                    array[0, 2] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 3:
                    array[1, 0] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 4:
                    array[1, 1] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 5:
                    array[1, 2] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 6:
                    array[2, 0] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 7:
                    array[2, 1] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 8:
                    array[2, 2] = 'x';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
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
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 1:
                    array[0, 1] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 2:
                    array[0, 2] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 3:
                    array[1, 0] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 4:
                    array[1, 1] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 5:
                    array[1, 2] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 6:
                    array[2, 0] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 7:
                    array[2, 1] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
                case 8:
                    array[2, 2] = 'o';
                    Console.Clear();
                    TurnLocalMultiplayer(array);
                    GameField(array);
                    break;
            }
        }

        public static void TurnLocalMultiplayer(char[,] array)
        {
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|    Single Player Game!  |");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine();
            HasWon(array);
            GameField(array);

            int nomerNaPole;
            try
            {
                if (!whichPlayer)
                {
                    Console.Write("Player 1: ");
                    nomerNaPole = int.Parse(Console.ReadLine());
                    if (nomerNaPole >= 0 && nomerNaPole <= 8)
                    {
                        whichPlayer ^= true;
                        GameInstructionsPlayer1(array, nomerNaPole);

                    }
                    else
                    {
                        Console.Write("yok");
                    }
                }
                if (whichPlayer == true)
                {
                    Console.Write("Player 2: ");
                    nomerNaPole = int.Parse(Console.ReadLine());
                    if (nomerNaPole >= 0 && nomerNaPole <= 8)
                    {
                        whichPlayer = false;
                        GameInstructionsPlayer2(array, nomerNaPole);
                    }
                    else
                    {
                        Console.WriteLine("yok");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Greshen input, opitaite pak");
                Console.ReadKey();
                Console.Clear();
                TurnLocalMultiplayer(array);
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
            if (array[0, 0] == 'o' && array[0, 1] == 'o' && array[0, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[1, 0] == 'o' && array[1, 1] == 'o' && array[1, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[2, 0] == 'o' && array[2, 1] == 'o' && array[2, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            //Vertical Wins
            if (array[0, 0] == 'o' && array[1, 0] == 'o' && array[2, 0] == '0')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 1] == 'o' && array[1, 1] == 'o' && array[2, 1] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 2] == 'o' && array[1, 2] == 'o' && array[2, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            //Diagonal Wins
            if (array[0, 0] == 'o' && array[1, 1] == 'o' && array[2, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 0] == 'o' && array[1, 1] == 'o' && array[2, 2] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            if (array[0, 2] == 'o' && array[1, 1] == 'o' && array[2, 0] == 'o')
            {
                Console.WriteLine("Player two has won!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
            else if (array[0, 0] != '0' && array[0, 1] != '1' && array[0, 2] != '2' && array[1, 0] != '3' && array[1, 1] != '4' && array[1, 2] != '5' && array[2, 0] != '6' && array[2, 1] != '7' && array[2, 2] != '8')
            {
                Console.WriteLine("There has been a draw!");
                Console.WriteLine("Press any button");
                Console.ReadKey();
                Console.Clear();
                StartGame();
            }
        }

        public static void GameField(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("| {0} |", array[i, j]);
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region OnlineMultiPlayerFunctions
        public static void ChatTest()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the IP address of the chat server: ");
            string ipAddress = Console.ReadLine();

            Console.Write("Enter the port number of the chat server: ");
            int port = int.Parse(Console.ReadLine());

            try
            {
                TcpClient client = new TcpClient(ipAddress, port);
                NetworkStream stream = client.GetStream();

                byte[] nameData = Encoding.UTF8.GetBytes(name);
                stream.Write(nameData, 0, nameData.Length);

                Console.WriteLine($"Connected to chat server at {ipAddress}:{port}");

                // Start a thread to receive messages from the server
                var receiveThread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            if (bytesRead > 0)
                            {
                                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                                Console.WriteLine(message);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error receiving message: {ex.Message}");
                            break;
                        }
                    }
                });
                receiveThread.Start();

                // Send messages to the server
                while (true)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            byte[] inputData = Encoding.UTF8.GetBytes(input);
                            stream.Write(inputData, 0, inputData.Length);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error sending message: {ex.Message}");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to chat server: {ex.Message}");
            }
        }
        #endregion

    }


}
