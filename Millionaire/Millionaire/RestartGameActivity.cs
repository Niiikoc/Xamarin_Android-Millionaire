using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Millionaire
{
    [Activity(Label = "RestartGameActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RestartGameActivity : DialogFragment
    {
        private Button mBtnYes;
        private Button mBtnNo;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.RestartGameLayout, container, false);
            
            mBtnYes = view.FindViewById<Button>(Resource.Id.BtnYes);
            mBtnNo = view.FindViewById<Button>(Resource.Id.BtnNo);

            mBtnYes.Click += MBtnYes_Click;
            mBtnNo.Click += MBtnNo_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

        private void MBtnNo_Click(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        private void MBtnYes_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this.Activity, typeof(StartGameActivity));
            this.StartActivity(intent);
        }
    }
}