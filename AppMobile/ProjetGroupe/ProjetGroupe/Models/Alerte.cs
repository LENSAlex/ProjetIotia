using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Alerte
    {
        public int Id_Alerte { get; set; }
        private int _BoxId;
        //Id_Box
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
        public string libelle { get; set; }
        public string description { get; set; }
        public DateTime date_alerte { get; set; }
        public static Alerte Load(int Id)
        {
            return new Alerte();
        }
    }
}
