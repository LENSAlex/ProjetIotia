using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class CasCovid
    {
        [JsonProperty("nom")]
        public string Nom { get; set; }
        [JsonProperty("NbCasCovid")]
        public int NbCasCovid { get; set; }
        [JsonProperty("name")]
        public string Nom2 { get; set; }

        public int Id { get; set; }
        public DateTime DateDeContamination { get; set; }

        private int _personneId;
        public int PersonneId
        {
            get
            {
                return _personneId;
            }
            set
            {
                _personneId = value;
                _personne = null;
            }
        }

        private Personne _personne;
        public Personne Personne
        {
            get
            {
                if (_personne == null && PersonneId != 0)
                    _personne = Personne.Load(PersonneId);
                return _personne;
            }
            set
            {
                _personne = value;
                _personneId = value?.Id ?? 0;
            }
        }
        public static Task<string> SendAlert(CasCovid cas)
        {
            return CasCovidManager.SendAlert(cas);
        }
        public Task<string> SendAlert()
        {
            return CasCovidManager.SendAlert(this);
        }
        public static async Task<string> Count()
        {
            List<CasCovid> cascovid = await CasCovidManager.ListCasCovid();
            int count = cascovid.Count;
            return count.ToString();
        }
        public static Task<List<CasCovid>> ListCasCovidFormation()
        {
            return CasCovidManager.ListCasCovidFormation();
        }
        public static Task<List<CasCovid>> ListCasCovidDepartement()
        {
            return CasCovidManager.ListCasCovidDepartement();
        }
    }
}
