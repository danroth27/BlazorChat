using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return Clients.All.SendAsync("SendAction", $"{Context.User.Identity.Name} joined");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return Clients.All.SendAsync("SendAction", $"{Context.User.Identity.Name} left");
        }

        public Task Send(string message)
        {
            return Clients.All.SendAsync("SendMessage", $"{Context.User.Identity.Name}: {message}");
        }
    }
}
