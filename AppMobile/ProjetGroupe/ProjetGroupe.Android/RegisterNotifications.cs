﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(ProjetGroupe.Droid.RegisterNotifications))]
namespace ProjetGroupe.Droid
{
    public class RegisterNotifications : IRegisterNotifications
    {
        public void RegisterDevice(string p_psnHandle, List<string> p_tags)
        {
            AndroidFireBaseMessagingService.SendRegistrationToServer(p_psnHandle, p_tags);
        }

        void IRegisterNotifications.UnRegisterDevice()
        {
            AndroidFireBaseMessagingService.UnRegisterDevice();
        }
    }
}