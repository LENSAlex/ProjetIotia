using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseE_Covid.IOTDevise
{
    public class Capteur
    {
        public int IdSalle { get; set; }

        public int IdDeviceType { get; set; }

        public string AddrMac { get; set; }

        public string AddrIp { get; set; }

        public string LibelleBox { get; set; }

        public string DescriptionBox { get; set; }

        public string DateInstallation { get; set; }

        public int IdValueType { get; set; }

        public string LibelleDevice { get; set; }

        public int SeuilMin { get; set; }

        public int SeuilMax { get; set; }
    }
}
