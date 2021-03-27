using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe
{
    public interface IRegisterNotifications
    {
        void RegisterDevice(string p_psnHandle, List<string> p_tags);
        void UnRegisterDevice();
    }
}
