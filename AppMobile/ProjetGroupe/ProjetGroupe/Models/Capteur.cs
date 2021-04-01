using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Capteur
    {
        [JsonProperty("Id")]
        public int Id_Device { get; set; }

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
        private int _CapteurTypeId;
        //Id_DeviceType
        public int CapteurTypeId
        {
            get
            {
                return _CapteurTypeId;
            }
            set
            {
                _CapteurTypeId = value;
                _capteurType = null;
            }
        }

        private CapteurType _capteurType;
        public CapteurType CapteurType
        {
            get
            {
                if (_capteurType == null && CapteurTypeId != 0)
                    _capteurType = CapteurType.Load(CapteurTypeId);
                return _capteurType;
            }
            set
            {
                _capteurType = value;
                _CapteurTypeId = value?.Id ?? 0;
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
        public decimal seuil_min { get; set; }
        public decimal seuil_max { get; set; }

        public static Task<Capteur> Load(int Id)
        {
            return CapteurManager.LoadCapteur(Id);
        }
        public static Task<ObservableCollection<Capteur>> List()
        {
            return CapteurManager.ListCapteur();
        }
        public static Task<string> Save(Capteur capteur)
        {
            return CapteurManager.Save(capteur);
        }
        public Task<string> Save()
        {
            return CapteurManager.Save(this);
        }
    }
}
