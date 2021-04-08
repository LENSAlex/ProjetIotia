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
        private int _ValueTypeId;
        public int ValueTypeId
        {
            get
            {
                return _ValueTypeId;
            }
            set
            {
                _ValueTypeId = value;
                _valueType = null;
            }
        }

        private ValueType _valueType;
        public ValueType ValueType
        {
            get
            {
                if (_valueType == null && ValueTypeId != 0)
                    _valueType = ValueType.Load(ValueTypeId);
                return _valueType;
            }
            set
            {
                _valueType = value;
                _ValueTypeId = value?.Id ?? 0;
            }
        }
        public decimal Valeur { get; set; }
        public DateTime date_historique { get; set; }
    }

}
