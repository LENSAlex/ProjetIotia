using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroupe.Droid
{
    /// <summary>
    /// Classe utilisé à la place de MainActivy lorsqu'on réouvre l'application. Elle monte un background pendant le chargement 
    /// </summary>
    [Activity(Theme = "@style/splashscreen", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        /// <summary>
        /// Charge le MainActivity 
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
        /// <summary>
        /// Bouton BackPressed Action (appareil pas application)
        /// </summary>
        public override void OnBackPressed() { }
    }
}