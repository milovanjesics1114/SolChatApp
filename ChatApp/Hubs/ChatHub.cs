using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ChatApp.Models;


namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        //preko user informacija
       /* public async Task BroadcastToUser(string user, string message, string userWhom)
    => await Clients.User(userWhom).SendAsync("ReceiveMessage", user, message, userWhom); */

        public string GetUserID()
        {
            return Context.UserIdentifier;
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

      
    }
}
