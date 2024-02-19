using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RT.Models
{
    public class ChatDBContext : DbContext
    {
        public ChatDBContext() : base("ChatDBContext")
        {

        }
        public DbSet<ChatContext> Chats { get; set; }
        public DbSet<User> Users { get; set; }

    }
}