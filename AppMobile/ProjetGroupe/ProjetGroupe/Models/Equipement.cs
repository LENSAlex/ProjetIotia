using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Equipement
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string EquipementType { get; set; }
        public static Equipement Load(int Id)
        {
            return new Equipement();
        }
    }
}
