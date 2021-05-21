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
        static Dictionary<string, string> ConnectedUsers = new Dictionary< string, string>();
       
        public void Connect(string UserName)
        {
            var id = Context.ConnectionId;

            ConnectedUsers.Add(UserName, id);
        }
        public async Task SendMessage(string sender, string message, string receiver)
        {
            var trimmedSender = sender.Trim();

            var trimmedReveiver = receiver.Trim();
            var id = Context.ConnectionId;
            if(!ConnectedUsers.ContainsKey(trimmedSender))
            {
                
                Console.WriteLine("Key: " + trimmedSender + " value: " + id);
                ConnectedUsers.Add(trimmedSender.Trim(), id);

                foreach (KeyValuePair<string, string> entry in ConnectedUsers)
                {
                    Console.WriteLine("entry: " + entry);
                }
            }
            Console.WriteLine("receiver: " + trimmedReveiver);
            string receiverId;
            if (ConnectedUsers.TryGetValue(trimmedReveiver, out receiverId))
            {

                //var receiverId = ConnectedUsers[receiver];

                Console.WriteLine("receiver: " + receiverId);
                Console.WriteLine("sender: " + GetConnectionId());
            
            
            await Clients.Client(receiverId).SendAsync("ReceiveMessage", trimmedSender, message);
            }
            
            
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
