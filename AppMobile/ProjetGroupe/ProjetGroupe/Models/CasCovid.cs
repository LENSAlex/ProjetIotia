using Newtonsoft.Json;
using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Classe CasCovid
    /// </summary>
    public class CasCovid
    {
        /// <summary>
        /// Nom du bâtiment
        /// </summary>
        [JsonProperty("nom")]
        public string Nom { get; set; }
        /// <summary>
        /// Nombre de cas
        /// </summary>
        [JsonProperty("NbCasCovid")]
        public int NbCasCovid { get; set; }
        /// <summary>
        /// Nom du département
        /// </summary>
        [JsonProperty("name")]
        public string NomDep { get; set; }
        /// <summary>
        /// Date de la contamination
        /// </summary>
        public DateTime DateDeContamination { get; set; }

        private int _personneId;
        /// <summary>
        /// Id de la personne ayant été signalé
        /// </summary>
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
        /// <summary>
        /// Getter/Setter permattant de récupéré l'id de la personne
        /// </summary>
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
        /// <summary>
        /// Méthode statique qui contacte le manager pour établir la requête POST vers l'API REST
        /// </summary>
        /// <param name="cas">Objet CasCovid</param>
        /// <returns>"Ok" si code = 200 sinon erreur</returns>
        public static Task<string> SendAlert(CasCovid cas)
        {
            return CasCovidManager.SendAlert(cas);
        }
        /// <summary>
        /// Methode renvoyer le nombre de CasCovid
        /// </summary>
        /// <returns>le nombre de cas en string (pour l'affichage)</returns>
        public static async Task<string> Count()
        {
            List<CasCovid> cascovid = await CasCovidManager.ListCasCovid();
            int count = cascovid.Count;
            return count.ToString();
        }
        /// <summary>
        /// Méthode statique donnant la liste des cas par formation en contactant l'API REST
        /// </summary>
        /// <returns>liste de CasCovid si code = 200 sinon erreur</returns>
        public static Task<List<CasCovid>> ListCasCovidFormation()
        {
            return CasCovidManager.ListCasCovidFormation();
        }
        /// <summary>
        /// Méthode statique donnant la liste des cas par département en contactant l'API REST
        /// </summary>
        /// <returns>liste de CasCovid si code = 200 sinon erreur</returns>
        public static Task<List<CasCovid>> ListCasCovidDepartement()
        {
            return CasCovidManager.ListCasCovidDepartement();
        }
    }
}
