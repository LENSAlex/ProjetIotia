using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class ValueType
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Unite { get; set; }
        public static ValueType Load(int Id)
        {
            return new ValueType();
        }

    }
}
