using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    public interface INotificationActionService
    {
        void TriggerAction(string action);
    }
}
