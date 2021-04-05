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
    [Activity(Theme = "@style/splashscreen", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    Task startupWork = new Task(() => { SimulateStartup(); });
        //    startupWork.Start();
        //}
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
    }
}