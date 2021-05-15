using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.IOTDevise
{
    /// <summary>
    /// Capteur et une class qui est utiliser pour recupére les valuer des requette Post , Put des Capteur
    /// </summary>
    public class Capteur
    {
        /// <summary>
        /// int Recupére la valeur du IdSalle
        /// </summary>
        public int IdSalle { get; set; }

        /// <summary>
        /// int Recupére la valeur du IdDeviceType
        /// </summary>
        public int IdDeviceType { get; set; }

        /// <summary>
        /// string Recupére la valeur du AddrMac
        /// </summary>
        public string AddrMac { get; set; }

        /// <summary>
        /// string Recupére la valeur du AddrIp
        /// </summary>
        public string AddrIp { get; set; }

        /// <summary>
        /// string Recupére la valeur du LibelleBox
        /// </summary>
        public string LibelleBox { get; set; }

        /// <summary>
        /// string Recupére la valeur du DescriptionBox
        /// </summary>
        public string DescriptionBox { get; set; }

        /// <summary>
        /// string Recupére la valeur du DateInstallation
        /// </summary>
        public string DateInstallation { get; set; }

        /// <summary>
        /// string Recupére la valeur du LibelleDevice
        /// </summary>
        public string LibelleDevice { get; set; }

        /// <summary>
        /// int Recupére la valeur du SeuilMin
        /// </summary>
        public int SeuilMin { get; set; }

        /// <summary>
        /// int Recupére la valeur du SeuilMax
        /// </summary>
        public int SeuilMax { get; set; }

        /// <summary>
        /// int Recupére la valeur du IdValeurType
        /// </summary>
        public int IdValeurType { get; set; }
    }
}
