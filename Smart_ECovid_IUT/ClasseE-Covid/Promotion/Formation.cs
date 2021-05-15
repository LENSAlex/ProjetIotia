using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClasseE_Covid.Promotion.Manager;

namespace ClasseE_Covid.Promotion
{
    /// <summary>
    /// Formation et une class qui est utiliser pour recupére les valuer des requette Post , Put Formation
    /// </summary>
    public class Formation
    {
        /// <summary>
        /// int Recupére la valeur du IdDepartement
        /// </summary>
        public int IdDepartement { get; set; }

        /// <summary>
        /// string Recupére la valeur du NomFormation
        /// </summary>
        public string NomFormation { get; set; }

        /// <summary>
        /// int Recupére la valeur du DureeFormation
        /// </summary>
        public int DureeFormation { get; set; }

        /// <summary>
        /// int Recupére la valeur du AnneePromotion
        /// </summary>
        public int AnneePromotion { get; set; }

        /// <summary>
        /// int Recupére la valeur du IdProfesseurPromotion
        /// </summary>
        public int IdProfesseurPromotion { get; set; }

    }
}
