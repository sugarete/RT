using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RT.Models;
using System.Net.Sockets;
using System.IO;

namespace RT
{
    public class ChatHub : Hub
    {

        public void rasp(string name, string message)
        {
            string raspIP = "172.28.128.190";
            string raspPort = "5500";
            string response = "";
            DateTime date = DateTime.Now;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect(raspIP, int.Parse(raspPort));
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                socket.Send(data);

                var buffer = new byte[1024];
                int received = socket.Receive(buffer);
                response = System.Text.Encoding.ASCII.GetString(buffer, 0, received);
            }

            using (var db = new ChatDBContext())
            {
                var chat = new ChatContext
                {
                    FromUserName = name,
                    Message = message,
                    Response = response,
                    Date = date,
                };
                db.Chats.Add(chat);
                db.SaveChanges();
            }
            Clients.All.addNewMessageToPage(name, message, date.ToString(), response);
        }
    }
}