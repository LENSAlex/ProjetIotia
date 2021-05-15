using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.Campus
{
    /// <summary>
    /// PostBatiementEtage et une class qui est utiliser pour recupére les valuer des requette Post des Etage du Batiement 
    /// </summary>
    public class PostBatiementEtage
    {
        /// <summary>
        /// string Recupére la valeur du nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// intRecupére la valeur du Superficie
        /// </summary>
        public int Superficie { get; set; }

        /// <summary>
        /// int  Recupére la valeur du IdCampus
        /// </summary>
        public int IdCampus { get; set; }

        /// <summary>
        /// string[]  Recupére la valeur du EtageSuperficie
        /// </summary>
        public string[] EtageSuperficie { get; set; }

        /// <summary>
        /// int  Recupére la valeur du NbEtage
        /// </summary>
        public int NbEtage { get; set; }

    }
}
