using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Models
{
    public class Alerte
    {
        public static Task<bool> SendNotification()
        {
            return AlerteManager.SendAlert();
        }
    }
}
