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
            get; set;
        }
        public decimal seuil_min { get; set; }
        public decimal seuil_max { get; set; }
    }
}
