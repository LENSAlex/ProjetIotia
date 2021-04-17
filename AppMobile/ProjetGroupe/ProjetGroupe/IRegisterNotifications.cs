using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe
{
    /// <summary>
    /// Interface pour les notifications
    /// </summary>
    public interface IRegisterNotifications
    {
        /// <summary>
        /// RegisterDevice
        /// </summary>
        /// <param name="p_psnHandle">p_psnHandle</param>
        /// <param name="p_tags">p_tags</param>
        void RegisterDevice(string p_psnHandle, List<string> p_tags);
        /// <summary>
        /// UnRegisterDevice
        /// </summary>
        void UnRegisterDevice();
    }
}
