using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.Promotion
{
    /// <summary>
    /// PostBatimentSalle et une class qui est utiliser pour recupére les valuer des requette Put  des Salle du Batiement 
    /// </summary>
    public class PutFormationId
    {
        /// <summary>
        /// int? Recupére la valeur de l'id de la Formation modifer
        /// </summary>
        public static int? IdFormation { get; set; }

        /// <summary>
        /// int? Recupére la valeur de l'id de la Promotion modifer
        /// </summary>
        public static int? IdPromo { get; set; }
    }
}
