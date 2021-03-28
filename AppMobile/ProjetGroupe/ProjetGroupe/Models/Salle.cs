using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Salle
    {
        public int Id { get; set; }

        private int _EtageId;
        public int EtageId
        {
            get
            {
                return _EtageId;
            }
            set
            {
                _EtageId = value;
                _etage = null;
            }
        }

        private Etage _etage;
        public Etage Etage
        {
            get
            {
                if (_etage == null && _EtageId != 0)
                    _etage = Etage.Load(_EtageId);
                return _etage;
            }
            set
            {
                _etage = value;
                _EtageId = value?.Id ?? 0;
            }
        }
        public int CapaciteMax { get; set; }
        public int surface { get; set; }
        public int Volume { get; set; }

        public static Salle Load(int Id)
        {
            return new Salle();
        }

    }
}
