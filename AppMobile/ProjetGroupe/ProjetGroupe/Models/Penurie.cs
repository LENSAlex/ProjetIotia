using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Class Pénurie
    /// </summary>
    public class Penurie
    {
        /// <summary>
        /// Id de l'équipement
        /// </summary>
        public int Id_Equipement { get; set; }
        /// <summary>
        /// Id de la salle ou se trouve la pénurie
        /// </summary>
        public int SalleId { get; set; }
        /// <summary>
        /// Pénurie ou non
        /// </summary>
        public bool Is_Penurie { get; set; }
        /// <summary>
        /// Date de la pénurie
        /// </summary>
        public DateTime date_maj { get; set; }
        /// <summary>
        /// Méthode statique prenant en paramètre les objets de la classe pénurie pour faire les PUT avec ses valeurs vers l'API REST
        /// </summary>
        /// <param name="penurie">Objet Pénurie</param>
        /// <returns></returns>
        public static Task<string> UpdateStock(Penurie penurie)
        {
            return PenurieManager.UpdateStock(penurie);
        }

    }
}
