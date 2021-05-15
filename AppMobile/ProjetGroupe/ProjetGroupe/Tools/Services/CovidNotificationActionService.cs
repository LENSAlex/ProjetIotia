using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Classe d'invoquation de la notification
    /// </summary>
    public class CovidNotificationActionService : ICovidNotificationActionService
    {
        readonly Dictionary<string, PushAction> _actionMappings = new Dictionary<string, PushAction>
        {
            { "action_a", PushAction.ActionA },
            { "action_b", PushAction.ActionB }
        };
        /// <summary>
        /// Appel de l'évènement
        /// </summary>

        public event EventHandler<PushAction> ActionTriggered = delegate { };

        /// <summary>
        /// Action d'invoquation
        /// </summary>
        /// <param name="action">nom de l'action</param>
        public void TriggerAction(string action)
        {
            if (!_actionMappings.TryGetValue(action, out var push))
                return;

            List<Exception> exceptions = new List<Exception>();

            foreach (var handler in ActionTriggered?.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, push);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }
    }
}
