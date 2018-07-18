using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using Com.Jkb.Slidemenu;
using System.Threading.Tasks;
using System;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Graphics;
using Lsjwzh.Widget.MaterialLoadingProgressBar;
using Android.Content;
using GR.Net.Maroulis.Library;
using Android.Views;
using Android.Content.PM;

namespace Millionaire
{
    [Activity(Label = "Millionaire", MainLauncher = true, Theme = "@style/appBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //var splash = new EasySplashScreen(this)
            //   .WithFullScreen()
            //   .WithTargetActivity(Java.Lang.Class.FromType(typeof(StartGameActivity)))
            //   .WithSplashTimeOut(5000)
            //   .WithLogo(Resource.Drawable.million_logo)
            //   .WithBackgroundColor(Color.ParseColor("#6600cc"));


            //View view = splash.Create();

            //SetContentView(view);

            SetContentView(Resource.Layout.WelcomeActivity);

            //just wait for 5 seconds...
            await Task.Delay(5000);

            var intent = new Intent(this, typeof(StartGameActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
        }

       
    }
}
