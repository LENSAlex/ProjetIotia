using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Capteur
    {
        public int Id_Device { get; set; }
        public int Id_Box { get; set; }
        public int Id_DeviceType { get; set; }
        public int Id_ValueType { get; set; }
        public decimal seuil_min { get; set; }
        public decimal seuil_max { get; set; }
    }
}
