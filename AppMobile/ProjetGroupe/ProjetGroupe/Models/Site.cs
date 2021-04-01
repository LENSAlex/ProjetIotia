using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Site
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public static Site Load(int Id)
        {
            return new Site();
        }
    }
}
