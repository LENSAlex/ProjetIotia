using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Historique
    {
        public int Id_Historique { get; set; }
        private int _BoxId;
        public int BoxId
        {
            get
            {
                return _BoxId;
            }
            set
            {
                _BoxId = value;
                _box = null;
            }
        }

        private Box _box;
        public Box Box
        {
            get
            {
                if (_box == null && BoxId != 0)
                    _box = Box.Load(BoxId);
                return _box;
            }
            set
            {
                _box = value;
                _BoxId = value?.Id ?? 0;
            }
        }
        public decimal Valeur { get; set; }
        public DateTime date_historique { get; set; }
    }

}
