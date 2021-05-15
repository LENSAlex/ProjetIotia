﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.IOTDevise
{
    /// <summary>
    /// Actionneur et une class qui est utiliser pour recupére les valuer des requette Post, Put des Actionneur
    /// </summary>
    public class Actionneur
    {
        /// <summary>
        /// int Recupére la valeur du IdBox
        /// </summary>
        public int IdBox { get; set; }

        /// <summary>
        /// int Recupére la valeur du IdValueType
        /// </summary>
        public int IdValueType { get; set; }

        /// <summary>
        /// string Recupére la valeur du Libelle
        /// </summary>
        public string Libelle { get; set; }
    }
}
