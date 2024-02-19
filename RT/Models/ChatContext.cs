using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RT.Models
{
    public class ChatContext
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FromUserName { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Response { get; set; }
    }
}