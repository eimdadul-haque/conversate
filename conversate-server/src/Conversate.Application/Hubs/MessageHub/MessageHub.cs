using Microsoft.AspNetCore.SignalR;
using Conversate.Application.Dtos.Messages;
using Microsoft.AspNetCore.Authorization;

namespace Conversate.Application.Hubs.MessageHub
{
    [Authorize]
    public class MessageHub : Hub
    {
        public async Task SendMessageToAll(MessageDto message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }   
}