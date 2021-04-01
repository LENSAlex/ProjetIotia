using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Etage
    {
        public int Id { get; set; }

        private int _BatimentId;
        public int BatimentId
        {
            get
            {
                return _BatimentId;
            }
            set
            {
                _BatimentId = value;
                _batiment = null;
            }
        }

        private Batiment _batiment;
        public Batiment Batiment
        {
            get
            {
                if (_batiment == null && _BatimentId != 0)
                    _batiment = Batiment.Load(_BatimentId);
                return _batiment;
            }
            set
            {
                _batiment = value;
                _BatimentId = value?.Id ?? 0;
            }
        }
        public string Numero { get; set; }
        public int Surface { get; set; }

        public static Etage Load(int Id)
        {
            return new Etage();
        }
    }
}
