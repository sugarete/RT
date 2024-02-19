using RT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace RT.Controllers
{
    public class RaspController : Controller
    {
        // GET: Rasp
        [HttpPost] 
        public ActionResult SendCommand2Rasp(string message)
        {
            string raspIP = "172.28.128.190";
            string raspPort = "5500";
            string response = "";
            if (ModelState.IsValid)
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(raspIP, int.Parse(raspPort));
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    socket.Send(data);

                    byte[] buffer = new byte[1024];
                    int received = socket.Receive(buffer);
                    response = System.Text.Encoding.ASCII.GetString(buffer, 0, received);
                }
                using (var db = new ChatDBContext())
                {
                    var chat = new ChatContext
                    {
                        FromUserName = Session["Username"].ToString(),
                        Message = message,
                        Response = response,
                        Date = DateTime.Now
                    };
                    db.Chats.Add(chat);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}