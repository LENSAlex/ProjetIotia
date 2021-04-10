using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    public interface IPushDemoNotificationActionService : INotificationActionService
    {
        event EventHandler<PushAction> ActionTriggered;
    }
}
