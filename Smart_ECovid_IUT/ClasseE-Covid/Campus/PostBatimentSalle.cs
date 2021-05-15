using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// PostBatimentSalle et une class qui est utiliser pour recupére les valuer des requette Post  des Salle du Batiement 
    /// </summary>
    public class PostBatimentSalle
    {
        /// <summary>
        /// string Recupére la valeur du nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// int Recupére la valeur du Volume
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// int Recupére la valeur du NomSalle
        /// </summary>
        public string NomSalle { get; set; }

        /// <summary>
        /// int Recupére la valeur du CapaciteMax
        /// </summary>
        public int CapaciteMax { get; set; }

        /// <summary>
        /// int Recupére la valeur du SalleSurface
        /// </summary>
        public int  SalleSurface { get; set; }

        /// <summary>
        /// int Recupére la valeur du IdEtage
        /// </summary>
        public int IdEtage { get; set; }
    }
}
