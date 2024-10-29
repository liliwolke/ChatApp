using Chat.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5172/chat")
            .Build();

        connection.On<ClientMessage>("ReceiveMessage", (clientMessage) =>
        {
            Console.WriteLine($"{clientMessage.Timestamp}: {clientMessage.Username}: {clientMessage.Message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to the chat hub.");

        Console.WriteLine("Введите ваше имя:");
        var userName = Console.ReadLine();

        
        while (true)
        {
            string message = Console.ReadLine();
            await connection.InvokeAsync("SendMessage", new {
                  UserName = userName,
        Message = message,
        CreateDate = DateTime.Now
    });
            }
        }
    }

