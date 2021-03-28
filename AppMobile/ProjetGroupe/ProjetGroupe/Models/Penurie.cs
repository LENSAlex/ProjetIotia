using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Penurie
    {
        public int Id_Equipement { get; set; }
        private int _SalleId;
        //Id_Box
        public int SalleId
        {
            get
            {
                return _SalleId;
            }
            set
            {
                _SalleId = value;
                _salle = null;
            }
        }

        private Salle _salle;
        public Salle Salle
        {
            get
            {
                if (_salle == null && SalleId != 0)
                    _salle = Salle.Load(SalleId);
                return _salle;
            }
            set
            {
                _salle = value;
                _SalleId = value?.Id ?? 0;
            }
        }
        public int Is_Penurie { get; set; }
        public DateTime date_maj { get; set; }

        public static Penurie Load(int Id)
        {
            return new Penurie();
        }

    }
}
