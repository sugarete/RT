using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using RT.Models.ViewModels;

namespace RT.Models.ViewModels
{
    public class AcsVM
    {
        public int Id { get; set; }
        public int LogID { get; set; }
        public string Action { get; set; }
        public string Hash { get; set; }
        public string HashType { get; set; }
        public List<AtkVM> AtkVMs { get; set;}
        public AcsVM()
        {
            AtkVMs = new List<AtkVM>();
        }
    }
}