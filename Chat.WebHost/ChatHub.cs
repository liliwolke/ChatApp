using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Chat.Models;

public class ChatHub : Hub
{
    public async Task SendMessage(ClientMessage message)
    {
        
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
