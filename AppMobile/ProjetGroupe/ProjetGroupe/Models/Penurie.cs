using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Penurie
    {
        public int Id_Equipement { get; set; }
        public int Id_Salle { get; set; }
        public bool Is_Penurie { get; set; }
        public DateTime date_maj { get; set; }

    }
}
