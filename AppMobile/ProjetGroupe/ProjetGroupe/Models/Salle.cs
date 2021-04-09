using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Salle
    {
        [JsonProperty("id_device")]
        public int Id_device { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }



        [JsonProperty("id_salle")]
        public int Id_salle { get; set; }

        [JsonProperty("id_personne")]
        public int Id_personne { get; set; }

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
        //Pour la recherche
        public static Task<List<Salle>> LoadSalleByNom(string nomSalle)
        {
            return SalleManager.LoadSalleByNom(nomSalle);
        }
        //Pour la pénurie
        public static Task<List<Salle>> ListSalleOfEleve()
        {
            return SalleManager.ListSalleOfEleve();
        }

        public static Task<List<CapteurType>> ListCapteurBySalleId(string nomSalle)
        {
            return SalleManager.ListCapteurBySalleId(nomSalle);
        }
    }
}
