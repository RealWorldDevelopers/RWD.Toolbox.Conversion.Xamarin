/******************************************************************************
 * Copyright(C) 2016 - All Right Reserved 
 * Real World Developers (www.realworlddevelopers.com) 
 * Unauthorized copying of this file, via any medium is strictly prohibited 
 * Written by Jim Stevens <jstevens@realworlddevelopers.com>  
 ******************************************************************************/

using Android.App;
using Android.Content.PM;
using Android.OS;

namespace RWD.Conversions.Droid
{
    [Activity(Label = "Conversions", Icon = "@drawable/ic_launcher",  MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

