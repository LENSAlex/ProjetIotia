using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Batiment
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Surface { get; set; }
        public static Batiment Load(int Id)
        {
            return new Batiment();
        }
    }
}
