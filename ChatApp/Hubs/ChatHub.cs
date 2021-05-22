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
       
        public void Connect(string user)
        {
            Console.WriteLine("connect invoked");
            var id = Context.ConnectionId;
            var trimmedUser = user.Trim();
            if (!ConnectedUsers.ContainsKey(trimmedUser))
            {

                Console.WriteLine("Key: " + trimmedUser + " value: " + id);
                ConnectedUsers.Add(trimmedUser, id);

            }
        }
        public async Task SendMessage(string sender, string message, string receiver)
        {
            var trimmedSender = sender.Trim();

            var trimmedReveiver = receiver.Trim();
           
            Console.WriteLine("receiver: " + trimmedReveiver);
            string receiverId;
            if (ConnectedUsers.TryGetValue(trimmedReveiver, out receiverId))
            {
                 await Clients.Clients(new List<string>() { receiverId, GetConnectionId() }).SendAsync("ReceiveMessage", trimmedSender, message);
                
            }
            
            
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

      
    }
}
