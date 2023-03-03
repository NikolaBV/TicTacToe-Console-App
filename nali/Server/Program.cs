using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    static void Main()
    {
        Console.Write("Enter the IP address to listen on: ");
        string ipAddress = Console.ReadLine();

        Console.Write("Enter the port number to listen on: ");
        int port = int.Parse(Console.ReadLine());

        TcpListener listener = new TcpListener(IPAddress.Parse(ipAddress), port);
        listener.Start();

        Console.WriteLine($"Listening on {ipAddress}:{port}");

        while (true)
        {
            try
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                // Start a thread to handle messages from the client
                var receiveThread = new Thread(() =>
                {
                    string name = "";
                    while (true)
                    {
                        try
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            if (bytesRead > 0)
                            {
                                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                                if (string.IsNullOrEmpty(name))
                                {
                                    // First message is the client's name
                                    name = message;
                                    Console.WriteLine($"Client {name} connected");
                                }
                                else
                                {
                                    // Broadcast message to all connected clients
                                    Console.WriteLine($"[{name}]: {message}");
                                    byte[] messageData = Encoding.UTF8.GetBytes($"[{name}]: {message}");
                                    foreach (TcpClient otherClient in Clients)
                                    {
                                        if (otherClient != client)
                                        {
                                            otherClient.GetStream().Write(messageData, 0, messageData.Length);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error receiving message from client {name}: {ex.Message}");
                            break;
                        }
                    }

                    // Remove client from list of connected clients
                    Clients.Remove(client);
                    Console.WriteLine($"Client {name} disconnected");
                    client.Close();
                });
                receiveThread.Start();

                // Add client to list of connected clients
                Clients.Add(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accepting client connection: {ex.Message}");
            }
        }
    }

    private static readonly List<TcpClient> Clients = new List<TcpClient>();
}