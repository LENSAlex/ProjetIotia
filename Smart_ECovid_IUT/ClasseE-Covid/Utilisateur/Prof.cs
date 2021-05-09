using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClasseE_Covid.Utilisateur.Manager;

namespace ClasseE_Covid.Utilisateur
{
    public class Prof
    {
        ManagerUtilisateur managerUtilisateur;

        [JsonPropertyName("id_professeur")]
        public int IdProf { get; set; }

        [JsonPropertyName("nom")]
        public string NomProf { get; set; }

        [JsonPropertyName("prenom")]
        public string PrenomProf { get; set; }

       // public static IEnumerable<Prof> _DDProf;

        //public IEnumerable<Prof> DDProf { get => _DDProf; set => _DDProf = value; }

        //public static Task<IEnumerable<Prof>> GetProf()
        //{
        //    return ManagerUtilisateur.LoadDDProf();
        //}
    }
}
