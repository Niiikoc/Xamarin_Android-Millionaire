using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Me.ITheBK;
using Newtonsoft.Json;

namespace Millionaire
{
    [Activity(Label = "AudienceActivity", Theme = "@style/appBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AudienceActivity : DialogFragment //Activity
    {
        BarChart barChart;
        MediaPlayer _player;
        int a, b, c, d;

        public  AudienceActivity(int A, int B, int C, int D)
        {
            this.a = A;
            this.b = B;
            this.c = C;
            this.d = D;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
        {
            base.OnCreateView(inflater, container, bundle);

            var view = inflater.Inflate(Resource.Layout.AudienceLayout, container, false);

            barChart = view.FindViewById<BarChart>(Resource.Id.bar_chart_vertical);
            barChart.BarMaxValue = 100;

            AudienceHelpFunction(a, b, c, d);

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

        public async void AudienceHelpFunction(int a, int b, int c, int d)
        {

            BarChartModel barChartModel = new BarChartModel();
            barChartModel.BarValue = a;
            barChartModel.BarColor = Color.ParseColor("#9C27B0");
            barChartModel.BarTag = "Α"; //You can set your own tag to bar model
            barChartModel.BarText = a.ToString();

            BarChartModel barChartModel2 = new BarChartModel();
            barChartModel2.BarValue = b;
            barChartModel2.BarColor = Color.ParseColor("#9C27B0");
            barChartModel2.BarTag = "Β"; //You can set your own tag to bar model
            barChartModel2.BarText = b.ToString();

            BarChartModel barChartModel3 = new BarChartModel();
            barChartModel3.BarValue = c;
            barChartModel3.BarColor = Color.ParseColor("#9C27B0");
            barChartModel3.BarTag = "Γ"; //You can set your own tag to bar model
            barChartModel3.BarText = c.ToString();

            BarChartModel barChartModel4 = new BarChartModel();
            barChartModel4.BarValue = d;
            barChartModel4.BarColor = Color.ParseColor("#9C27B0");
            barChartModel4.BarTag = "Δ"; //You can set your own tag to bar model
            barChartModel4.BarText = d.ToString();

            barChart.AddBar(barChartModel);
            barChart.AddBar(barChartModel2);
            barChart.AddBar(barChartModel3);
            barChart.AddBar(barChartModel4);

            await Task.Delay(1500);
            Sounds();

            await Task.Delay(7000);
            this.Dismiss();
        }

        public void Sounds()
        {
            if(a > b && a > c && a > d)
            {
                _player = MediaPlayer.Create(this.Context, Resource.Raw.Audience_A);
                _player.Start();
            }
            else if (b > a && b > c && b > d)
            {
                _player = MediaPlayer.Create(this.Context, Resource.Raw.Audience_B);
                _player.Start();
            }
            else if (c > a && c > b && c > d)
            {
                _player = MediaPlayer.Create(this.Context, Resource.Raw.Audience_C);
                _player.Start();
            }
            else
            {
                _player = MediaPlayer.Create(this.Context, Resource.Raw.Audience_D);
                _player.Start();
            }
        }

    }
}