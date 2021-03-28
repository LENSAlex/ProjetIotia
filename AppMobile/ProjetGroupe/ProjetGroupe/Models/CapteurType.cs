using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class CapteurType
    {
        public int Id { get; set; }
        public string LibelleType { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }

        public static CapteurType Load(int Id)
        {
            return new CapteurType();
        }
    }
}
