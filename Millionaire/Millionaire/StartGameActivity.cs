using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;
using GR.Net.Maroulis.Library;

namespace Millionaire
{
    [Activity(Label = "SplashActivity", Theme = "@style/appBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class StartGameActivity : AppCompatActivity
    {
        private Button mStartGame;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.StartGame);

            mStartGame = FindViewById<Button>(Resource.Id.mainButton);
            AdView adView = FindViewById<AdView>(Resource.Id.adView);
            LottieAnimationView LoadingView = FindViewById<LottieAnimationView>(Resource.Id.animation_loading);


            AdRequest adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);

            mStartGame.Click += async (object sender, EventArgs args) =>
            {
                LoadingView.SetAnimation("trail_loading.json");
                LoadingView.Loop(true);
                mStartGame.Visibility = ViewStates.Invisible;

                await Task.Delay(7000);

                var intent = new Intent(this, typeof(FirstPage));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
                Finish();
            };
        }

    }
}