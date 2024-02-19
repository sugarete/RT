using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RT.Models.ViewModels
{
    public class AtkVM
    {
        public int Id { get; set; }
        public string ATK_Name { get; set; }

        public int Min_Length { get; set; }

        public int Max_Length { get; set; }

        public string Charset { get; set; }
    }
}