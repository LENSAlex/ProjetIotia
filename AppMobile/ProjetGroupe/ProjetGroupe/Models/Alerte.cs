using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Alerte
    {
        public int Id_Alerte { get; set; }
        public int Id_Box { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public DateTime date_alerte { get; set; }
    }
}
