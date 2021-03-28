using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Models
{
    public class Box
    {
        public int Id { get; set; }
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
        public string AdresseMac { get; set; }
        public string AdresseIP { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime DateInstallation { get; set; }

        public static Box Load(int Id)
        {
            return new Box();
        }
    }
}
