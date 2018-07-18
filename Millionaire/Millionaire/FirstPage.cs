using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;
using Com.Jkb.Slidemenu;
using Plugin.Connectivity;

namespace Millionaire
{
    [Activity(Label = "Εκατομμυριούχος", Theme = "@style/appBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FirstPage : Activity
    {

        private static ProgressBar circularbar;
        private static Button ButtonA, ButtonA1, ButtonAtext, ButtonA2;
        private static Button ButtonB, ButtonB1, ButtonBtext, ButtonB2;
        private static Button ButtonC, ButtonC1, ButtonCtext, ButtonC2;
        private static Button ButtonD, ButtonD1, ButtonDtext, ButtonD2;
        private TextView mTextMillion, mText500000, mText250000, mText125000, mText64000, mText32000,
                         mText16000, mText8000, mText4000, mText2000, mText1000, mText500, mText300, mText100;
        private ImageView mLeftImage, mRightImage, mAudience, mPhone, mHalf_Half;
        private SlideMenuLayout slideMenuLayout;
        private TextView CountDownTimer, mQuestionsView, mTextOfScore;
        private int count = 30;
        bool musicStatus;
        private System.Timers.Timer _timer;
        private int score = 1;
        private string[] lines;
        private IEnumerable<string> lines2;
        private int randomLineNumber;
        List<int> temp1 = new List<int>();
        List<int> temp2 = new List<int>();
        List<int> temp3 = new List<int>();
        private int w, z, y, k, biggestNum;
        int alpha, beta, gamma, delta;
        double perc;
        MediaPlayer _player, _ScoreSound, _Phone;
        Random r = new Random();
        private string first, second, third, fourth, CorrectAnswer;
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        string FirstFileOfQueastion = "firstLevelQuestions.txt";
        string SecondFileOfQueastion = "SecondLevelQuestions.txt";
        string ThirdFileOfQueastion = "ThirdLevelQuestions.txt";
        string FirstFileOfAnswers = "firstLevelAnswers.txt";
        string SecondFileOfAnswers = "SecondLevelAnswers.txt";
        string ThirdFileOfAnswers = "ThirdLevelAnswers.txt";
        protected InterstitialAd mInterstitialAd;
        private readonly RandomNumberGenerator rng = new RNGCryptoServiceProvider();


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstPage);

            circularbar = FindViewById<ProgressBar>(Resource.Id.Progressbar);
            mQuestionsView = FindViewById<TextView>(Resource.Id.questionsView);
            mTextOfScore = FindViewById<TextView>(Resource.Id.textOfScore);
            ButtonA = FindViewById<Button>(Resource.Id.buttonA);
            ButtonA1 = FindViewById<Button>(Resource.Id.buttonA1);
            ButtonAtext = FindViewById<Button>(Resource.Id.buttonAtext);
            ButtonA2 = FindViewById<Button>(Resource.Id.buttonA2);
            ButtonB = FindViewById<Button>(Resource.Id.buttonB);
            ButtonB1 = FindViewById<Button>(Resource.Id.buttonB1);
            ButtonBtext = FindViewById<Button>(Resource.Id.buttonBtext);
            ButtonB2 = FindViewById<Button>(Resource.Id.buttonB2);
            ButtonC = FindViewById<Button>(Resource.Id.buttonC);
            ButtonC1 = FindViewById<Button>(Resource.Id.buttonC1);
            ButtonCtext = FindViewById<Button>(Resource.Id.buttonCtext);
            ButtonC2 = FindViewById<Button>(Resource.Id.buttonC2);
            ButtonD = FindViewById<Button>(Resource.Id.buttonD);
            ButtonD1 = FindViewById<Button>(Resource.Id.buttonD1);
            ButtonDtext = FindViewById<Button>(Resource.Id.buttonDtext);
            ButtonD2 = FindViewById<Button>(Resource.Id.buttonD2);
            CountDownTimer = FindViewById<TextView>(Resource.Id.txtCountDown);
            slideMenuLayout = FindViewById<SlideMenuLayout>(Resource.Id.mainSlideMenu);
            mLeftImage = FindViewById<ImageView>(Resource.Id.LeftImage);
            mRightImage = FindViewById<ImageView>(Resource.Id.rightImage);
            mAudience = FindViewById<ImageView>(Resource.Id.BtnAudience);
            mPhone = FindViewById<ImageView>(Resource.Id.BtnPhone);
            mHalf_Half = FindViewById<ImageView>(Resource.Id.Btn5050);
            mTextMillion = FindViewById<TextView>(Resource.Id.textMillion);
            mText500000 = FindViewById<TextView>(Resource.Id.text500000);
            mText250000 = FindViewById<TextView>(Resource.Id.text250000);
            mText125000 = FindViewById<TextView>(Resource.Id.text125000);
            mText64000 = FindViewById<TextView>(Resource.Id.text64000);
            mText32000 = FindViewById<TextView>(Resource.Id.text32000);
            mText16000 = FindViewById<TextView>(Resource.Id.text16000);
            mText8000 = FindViewById<TextView>(Resource.Id.text8000);
            mText4000 = FindViewById<TextView>(Resource.Id.text4000);
            mText2000 = FindViewById<TextView>(Resource.Id.text2000);
            mText1000 = FindViewById<TextView>(Resource.Id.text1000);
            mText500 = FindViewById<TextView>(Resource.Id.text500);
            mText300 = FindViewById<TextView>(Resource.Id.text300);
            mText100 = FindViewById<TextView>(Resource.Id.text100);

            ButtonA.Click += ButtonA_ClickAsync;
            ButtonA1.Click += ButtonA_ClickAsync;
            ButtonAtext.Click += ButtonA_ClickAsync;
            ButtonA2.Click += ButtonA_ClickAsync;
            ButtonB.Click += ButtonB_Click;
            ButtonB1.Click += ButtonB_Click;
            ButtonBtext.Click += ButtonB_Click;
            ButtonB2.Click += ButtonB_Click;
            ButtonC.Click += ButtonC_Click;
            ButtonC1.Click += ButtonC_Click;
            ButtonCtext.Click += ButtonC_Click;
            ButtonC2.Click += ButtonC_Click;
            ButtonD.Click += ButtonD_Click;
            ButtonD1.Click += ButtonD_Click;
            ButtonDtext.Click += ButtonD_Click;
            ButtonD2.Click += ButtonD_Click;


            mInterstitialAd = new InterstitialAd(this);
            mInterstitialAd.AdUnitId = GetString(Resource.String.Interstitial_Advertising);
            mInterstitialAd.AdListener = new AdListener(this);

            circularbar.Max = 30;
            circularbar.Progress = 30;
            circularbar.SecondaryProgress = 30;

            mLeftImage.Click += (object sender, EventArgs args) =>
            {
                Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                ExitGameActivity popupWindow = new ExitGameActivity();
                popupWindow.Show(fragment, "Dialog Fragment");
            };
            mRightImage.Click += MRightImage_Click;

                mHalf_Half.Click += MHalf_Half_Click;
            mAudience.Click += MAudience_ClickAsync;
            mPhone.Click += MPhone_Click;
            RequestNewInterstitial();
            mText100.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
            mTextOfScore.Text = "100€";
            musicStatus = true;
            NextQuestion();
        }

        protected void RequestNewInterstitial()
        {
            if (CrossConnectivity.Current.IsConnected == true)
            {
                var adRequest = new AdRequest.Builder().Build();
                mInterstitialAd.LoadAd(adRequest);
            }
        }

        class AdListener : Android.Gms.Ads.AdListener
        {
            FirstPage that;

            public AdListener(FirstPage t)
            {
                that = t;
            }

            public override void OnAdClosed()
            {
                that.RequestNewInterstitial();
                that.NextQuestion();
            }
        }


        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            count--;
            CountDownTimer.Text = count.ToString();
            circularbar.Progress = count;
            if (count == 0)
            {
                _timer.Stop();
                var _endTime = MediaPlayer.Create(this, Resource.Raw.End_time);
                _endTime.Start();
                DisableButtonClicks();
                Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                RestartGameActivity popupWindow = new RestartGameActivity();
                popupWindow.Show(fragment, "Dialog Fragment");
            }
        }

        //protected override void OnStart()
        //{
        //    base.OnStart();
        //    BackgroundMusic.Looping = true;
        //}

        private async void NextQuestion()
        {
            //BackgroundMusic.Start();
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimedEvent;
            _timer.Enabled = true;
            await Task.Delay(1000);

            mHalf_Half.Clickable = true;
            mAudience.Clickable = true;
            mPhone.Clickable = true;

            ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonAtext.Clickable = true;
            ButtonA.Clickable = true;
            ButtonA1.Clickable = true;
            ButtonA2.Clickable = true;

            ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonBtext.Clickable = true;
            ButtonB.Clickable = true;
            ButtonB1.Clickable = true;
            ButtonB2.Clickable = true;

            ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonCtext.Clickable = true;
            ButtonC.Clickable = true;
            ButtonC1.Clickable = true;
            ButtonC2.Clickable = true;

            ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#6600cc"));
            ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up);
            ButtonDtext.Clickable = true;
            ButtonD.Clickable = true;
            ButtonD1.Clickable = true;
            ButtonD2.Clickable = true;

            if (score <= 5)
            {
                File.Delete(documentsPath + FirstFileOfQueastion);
                File.Delete(documentsPath + FirstFileOfAnswers);

                temp1.Add(randomLineNumber);
                if (!File.Exists(documentsPath + FirstFileOfQueastion))
                {
                    // ερωτησεις
                    using (var asset = Assets.Open("questions-level-first.txt"))
                    using (var dest = File.Create(documentsPath + FirstFileOfQueastion))
                        asset.CopyTo(dest);
                    lines = System.IO.File.ReadAllLines(documentsPath + FirstFileOfQueastion);
                    // απαντησεις
                    using (var asset2 = Assets.Open("answers-level-first.txt"))
                    using (var dest = File.Create(documentsPath + FirstFileOfAnswers))
                        asset2.CopyTo(dest);
                    lines2 = System.IO.File.ReadLines(documentsPath + FirstFileOfAnswers).ToArray();
                }
                else
                {
                    lines = System.IO.File.ReadAllLines(documentsPath + FirstFileOfQueastion);
                    lines2 = System.IO.File.ReadLines(documentsPath + FirstFileOfAnswers).ToArray();
                }
                RandomNumber();
                if (!temp1.Contains<int>(randomLineNumber))
                {
                    ShowFirstQuestions();
                }
                else
                {
                    RandomNumber();
                    ShowFirstQuestions();
                }
            }
            else if (score > 5 && score <= 10)
            {
                File.Delete(documentsPath + SecondFileOfQueastion);
                File.Delete(documentsPath + SecondFileOfAnswers);

                temp2.Add(randomLineNumber);
                if (!File.Exists(documentsPath + SecondFileOfQueastion) && !File.Exists(documentsPath + SecondFileOfAnswers))
                {
                    // ερωτησεις
                    using (var asset = Assets.Open("questions-lvl2.txt"))
                    using (var dest = File.Create(documentsPath + SecondFileOfQueastion))
                        asset.CopyTo(dest);
                    lines = System.IO.File.ReadAllLines(documentsPath + SecondFileOfQueastion);
                    // απαντησεις
                    using (var asset2 = Assets.Open("answers_lvl2.txt"))
                    using (var dest = File.Create(documentsPath + SecondFileOfAnswers))
                        asset2.CopyTo(dest);
                    lines2 = System.IO.File.ReadLines(documentsPath + SecondFileOfAnswers).ToArray();
                }
                else
                {
                    lines = System.IO.File.ReadAllLines(documentsPath + SecondFileOfQueastion);
                    lines2 = System.IO.File.ReadLines(documentsPath + SecondFileOfAnswers).ToArray();
                }
                RandomNumber();
                if (!temp2.Contains<int>(randomLineNumber))
                {
                    ShowSecondQuestions();
                }
                else
                {
                    RandomNumber();
                    ShowSecondQuestions();
                }

            }
            else if (score > 10)
            {
                File.Delete(documentsPath + ThirdFileOfQueastion);
                File.Delete(documentsPath + ThirdFileOfAnswers);

                temp3.Add(randomLineNumber);
                if (!File.Exists(documentsPath + ThirdFileOfQueastion) && !File.Exists(documentsPath + ThirdFileOfAnswers))
                {
                    // ερωτησεις
                    using (var asset = Assets.Open("questions-lvl3.txt"))
                    using (var dest = File.Create(documentsPath + ThirdFileOfQueastion))
                        asset.CopyTo(dest);
                    lines = System.IO.File.ReadAllLines(documentsPath + ThirdFileOfQueastion);
                    // απαντησεις
                    using (var asset2 = Assets.Open("answers_lvl3.txt"))
                    using (var dest = File.Create(documentsPath + ThirdFileOfAnswers))
                        asset2.CopyTo(dest);
                    lines2 = System.IO.File.ReadLines(documentsPath + ThirdFileOfAnswers).ToArray();
                }
                else
                {
                    lines = System.IO.File.ReadAllLines(documentsPath + ThirdFileOfQueastion);
                    lines2 = System.IO.File.ReadLines(documentsPath + ThirdFileOfAnswers).ToArray();
                }
                RandomNumber();
                if (!temp3.Contains<int>(randomLineNumber))
                {
                    ShowThirdQuestions();
                }
                else
                {
                    RandomNumber();
                    ShowThirdQuestions();
                }
            }
        }

        private void ShowFirstQuestions()
        {
            switch (randomLineNumber)
            {
                case 0:
                    {
                        string a = lines2.Skip(randomLineNumber).First();
                        string b = lines2.Skip(randomLineNumber + 1).First();
                        string c = lines2.Skip(randomLineNumber + 2).First();
                        string d = lines2.Skip(randomLineNumber + 3).First();
                        ButtonAtext.Text = a; ButtonBtext.Text = b; ButtonCtext.Text = c; ButtonDtext.Text = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ελλάδα.";
                        break;
                    }
                case 1:
                    {

                        string a = lines2.Skip(randomLineNumber + 4).First();
                        string b = lines2.Skip(randomLineNumber + 5).First();
                        string c = lines2.Skip(randomLineNumber + 6).First();
                        string d = lines2.Skip(randomLineNumber + 7).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Βιομάζα.";
                        break;
                    }
                case 2:
                    {
                        string a = lines2.Skip(randomLineNumber + 8).First();
                        string b = lines2.Skip(randomLineNumber + 9).First();
                        string c = lines2.Skip(randomLineNumber + 10).First();
                        string d = lines2.Skip(randomLineNumber + 11).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η Ισπανία.";
                        break;
                    }
                case 3:
                    {
                        string a = lines2.Skip(randomLineNumber + 12).First();
                        string b = lines2.Skip(randomLineNumber + 13).First();
                        string c = lines2.Skip(randomLineNumber + 14).First();
                        string d = lines2.Skip(randomLineNumber + 15).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Σικελία.";
                        break;
                    }
                case 4:
                    {

                        string a = lines2.Skip(randomLineNumber + 16).First();
                        string b = lines2.Skip(randomLineNumber + 17).First();
                        string c = lines2.Skip(randomLineNumber + 18).First();
                        string d = lines2.Skip(randomLineNumber + 19).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ιστιοπλοΐα.";
                        break;
                    }
                case 5:
                    {
                        string a = lines2.Skip(randomLineNumber + 20).First();
                        string b = lines2.Skip(randomLineNumber + 21).First();
                        string c = lines2.Skip(randomLineNumber + 22).First();
                        string d = lines2.Skip(randomLineNumber + 23).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Σφυριά.";
                        break;
                    }
                case 6:
                    {
                        string a = lines2.Skip(randomLineNumber + 24).First();
                        string b = lines2.Skip(randomLineNumber + 25).First();
                        string c = lines2.Skip(randomLineNumber + 26).First();
                        string d = lines2.Skip(randomLineNumber + 27).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ελύτης.";
                        break;
                    }
                case 7:
                    {
                        string a = lines2.Skip(randomLineNumber + 28).First();
                        string b = lines2.Skip(randomLineNumber + 29).First();
                        string c = lines2.Skip(randomLineNumber + 30).First();
                        string d = lines2.Skip(randomLineNumber + 31).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η Αμυγδάλου.";
                        break;
                    }
                case 8:
                    {
                        string a = lines2.Skip(randomLineNumber + 32).First();
                        string b = lines2.Skip(randomLineNumber + 33).First();
                        string c = lines2.Skip(randomLineNumber + 34).First();
                        string d = lines2.Skip(randomLineNumber + 35).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Samuel Morse.";
                        break;
                    }
                case 9:
                    {
                        string a = lines2.Skip(randomLineNumber + 36).First();
                        string b = lines2.Skip(randomLineNumber + 37).First();
                        string c = lines2.Skip(randomLineNumber + 38).First();
                        string d = lines2.Skip(randomLineNumber + 39).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Αργεντινή.";
                        break;
                    }

                case 10:
                    {
                        string a = lines2.Skip(randomLineNumber + 40).First();
                        string b = lines2.Skip(randomLineNumber + 41).First();
                        string c = lines2.Skip(randomLineNumber + 42).First();
                        string d = lines2.Skip(randomLineNumber + 43).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Φεβρουάριος.";
                        break;
                    }
                case 11:
                    {

                        string a = lines2.Skip(randomLineNumber + 44).First();
                        string b = lines2.Skip(randomLineNumber + 45).First();
                        string c = lines2.Skip(randomLineNumber + 46).First();
                        string d = lines2.Skip(randomLineNumber + 47).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "1789.";
                        break;
                    }
                case 12:
                    {
                        string a = lines2.Skip(randomLineNumber + 48).First();
                        string b = lines2.Skip(randomLineNumber + 49).First();
                        string c = lines2.Skip(randomLineNumber + 50).First();
                        string d = lines2.Skip(randomLineNumber + 51).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Πολεμικός στόλος.";
                        break;
                    }
                case 13:
                    {
                        string a = lines2.Skip(randomLineNumber + 52).First();
                        string b = lines2.Skip(randomLineNumber + 53).First();
                        string c = lines2.Skip(randomLineNumber + 54).First();
                        string d = lines2.Skip(randomLineNumber + 55).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Στον Σαρωνικό.";
                        break;
                    }
                case 14:
                    {
                        string a = lines2.Skip(randomLineNumber + 56).First();
                        string b = lines2.Skip(randomLineNumber + 57).First();
                        string c = lines2.Skip(randomLineNumber + 58).First();
                        string d = lines2.Skip(randomLineNumber + 59).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "1989.";
                        break;
                    }
                case 15:
                    {
                        string a = lines2.Skip(randomLineNumber + 60).First();
                        string b = lines2.Skip(randomLineNumber + 61).First();
                        string c = lines2.Skip(randomLineNumber + 62).First();
                        string d = lines2.Skip(randomLineNumber + 63).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Με μήλα.";
                        break;
                    }
                case 16:
                    {
                        string a = lines2.Skip(randomLineNumber + 64).First();
                        string b = lines2.Skip(randomLineNumber + 65).First();
                        string c = lines2.Skip(randomLineNumber + 66).First();
                        string d = lines2.Skip(randomLineNumber + 67).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Κασπία.";
                        break;
                    }
                case 17:
                    {
                        string a = lines2.Skip(randomLineNumber + 68).First();
                        string b = lines2.Skip(randomLineNumber + 69).First();
                        string c = lines2.Skip(randomLineNumber + 70).First();
                        string d = lines2.Skip(randomLineNumber + 71).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ρόδο.";
                        break;
                    }
                case 18:
                    {
                        string a = lines2.Skip(randomLineNumber + 72).First();
                        string b = lines2.Skip(randomLineNumber + 73).First();
                        string c = lines2.Skip(randomLineNumber + 74).First();
                        string d = lines2.Skip(randomLineNumber + 75).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η Αθηνά.";
                        break;
                    }
                case 19:
                    {
                        string a = lines2.Skip(randomLineNumber + 76).First();
                        string b = lines2.Skip(randomLineNumber + 77).First();
                        string c = lines2.Skip(randomLineNumber + 78).First();
                        string d = lines2.Skip(randomLineNumber + 79).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Διάχυση.";
                        break;
                    }
                case 20:
                    {
                        string a = lines2.Skip(randomLineNumber + 80).First();
                        string b = lines2.Skip(randomLineNumber + 81).First();
                        string c = lines2.Skip(randomLineNumber + 82).First();
                        string d = lines2.Skip(randomLineNumber + 83).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Άπειρα κοινά σημεία.";
                        break;
                    }
                case 21:
                    {
                        string a = lines2.Skip(randomLineNumber + 84).First();
                        string b = lines2.Skip(randomLineNumber + 85).First();
                        string c = lines2.Skip(randomLineNumber + 86).First();
                        string d = lines2.Skip(randomLineNumber + 87).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Χέρι.";
                        break;
                    }
                case 22:
                    {
                        string a = lines2.Skip(randomLineNumber + 88).First();
                        string b = lines2.Skip(randomLineNumber + 89).First();
                        string c = lines2.Skip(randomLineNumber + 90).First();
                        string d = lines2.Skip(randomLineNumber + 91).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Valentino Rossi.";
                        break;
                    }
                case 23:
                    {
                        string a = lines2.Skip(randomLineNumber + 92).First();
                        string b = lines2.Skip(randomLineNumber + 93).First();
                        string c = lines2.Skip(randomLineNumber + 94).First();
                        string d = lines2.Skip(randomLineNumber + 95).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Βαλέττα.";
                        break;
                    }
                case 24:
                    {

                        string a = lines2.Skip(randomLineNumber + 96).First();
                        string b = lines2.Skip(randomLineNumber + 97).First();
                        string c = lines2.Skip(randomLineNumber + 98).First();
                        string d = lines2.Skip(randomLineNumber + 99).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Λευκάδα.";
                        break;
                    }
                case 25:
                    {
                        string a = lines2.Skip(randomLineNumber + 100).First();
                        string b = lines2.Skip(randomLineNumber + 101).First();
                        string c = lines2.Skip(randomLineNumber + 102).First();
                        string d = lines2.Skip(randomLineNumber + 103).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Λιέγη.";
                        break;
                    }
                case 26:
                    {
                        string a = lines2.Skip(randomLineNumber + 104).First();
                        string b = lines2.Skip(randomLineNumber + 105).First();
                        string c = lines2.Skip(randomLineNumber + 106).First();
                        string d = lines2.Skip(randomLineNumber + 107).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "1594.";
                        break;
                    }
                case 27:
                    {
                        string a = lines2.Skip(randomLineNumber + 108).First();
                        string b = lines2.Skip(randomLineNumber + 109).First();
                        string c = lines2.Skip(randomLineNumber + 110).First();
                        string d = lines2.Skip(randomLineNumber + 111).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ποσειδώνα.";
                        break;
                    }
            }
        }

        private void ShowSecondQuestions()
        {
            switch (randomLineNumber)
            {
                case 0:
                    {
                        string a = lines2.Skip(randomLineNumber).First();
                        string b = lines2.Skip(randomLineNumber + 1).First();
                        string c = lines2.Skip(randomLineNumber + 2).First();
                        string d = lines2.Skip(randomLineNumber + 3).First();
                        ButtonAtext.Text = a; ButtonBtext.Text = b; ButtonCtext.Text = c; ButtonDtext.Text = d;
                        tuxaia_seira();
                        CorrectAnswer = "1974.";
                        break;
                    }
                case 1:
                    {

                        string a = lines2.Skip(randomLineNumber + 4).First();
                        string b = lines2.Skip(randomLineNumber + 5).First();
                        string c = lines2.Skip(randomLineNumber + 6).First();
                        string d = lines2.Skip(randomLineNumber + 7).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "7.";
                        break;
                    }
                case 2:
                    {
                        string a = lines2.Skip(randomLineNumber + 8).First();
                        string b = lines2.Skip(randomLineNumber + 9).First();
                        string c = lines2.Skip(randomLineNumber + 10).First();
                        string d = lines2.Skip(randomLineNumber + 11).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Για τον ιππόκαμπο.";
                        break;
                    }
                case 3:
                    {
                        string a = lines2.Skip(randomLineNumber + 12).First();
                        string b = lines2.Skip(randomLineNumber + 13).First();
                        string c = lines2.Skip(randomLineNumber + 14).First();
                        string d = lines2.Skip(randomLineNumber + 15).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Άνωση.";
                        break;
                    }
                case 4:
                    {

                        string a = lines2.Skip(randomLineNumber + 16).First();
                        string b = lines2.Skip(randomLineNumber + 17).First();
                        string c = lines2.Skip(randomLineNumber + 18).First();
                        string d = lines2.Skip(randomLineNumber + 19).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ερμής.";
                        break;
                    }
                case 5:
                    {
                        string a = lines2.Skip(randomLineNumber + 20).First();
                        string b = lines2.Skip(randomLineNumber + 21).First();
                        string c = lines2.Skip(randomLineNumber + 22).First();
                        string d = lines2.Skip(randomLineNumber + 23).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Κινέζικα.";
                        break;
                    }
                case 6:
                    {
                        string a = lines2.Skip(randomLineNumber + 24).First();
                        string b = lines2.Skip(randomLineNumber + 25).First();
                        string c = lines2.Skip(randomLineNumber + 26).First();
                        string d = lines2.Skip(randomLineNumber + 27).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Δράκοντας.";
                        break;
                    }
                case 7:
                    {
                        string a = lines2.Skip(randomLineNumber + 28).First();
                        string b = lines2.Skip(randomLineNumber + 29).First();
                        string c = lines2.Skip(randomLineNumber + 30).First();
                        string d = lines2.Skip(randomLineNumber + 31).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ατσάλι.";
                        break;
                    }
                case 8:
                    {
                        string a = lines2.Skip(randomLineNumber + 32).First();
                        string b = lines2.Skip(randomLineNumber + 33).First();
                        string c = lines2.Skip(randomLineNumber + 34).First();
                        string d = lines2.Skip(randomLineNumber + 35).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Πέντε.";
                        break;
                    }
                case 9:
                    {
                        string a = lines2.Skip(randomLineNumber + 36).First();
                        string b = lines2.Skip(randomLineNumber + 37).First();
                        string c = lines2.Skip(randomLineNumber + 38).First();
                        string d = lines2.Skip(randomLineNumber + 39).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ήλιο.";
                        break;
                    }
                case 10:
                    {
                        string a = lines2.Skip(randomLineNumber + 40).First();
                        string b = lines2.Skip(randomLineNumber + 41).First();
                        string c = lines2.Skip(randomLineNumber + 42).First();
                        string d = lines2.Skip(randomLineNumber + 43).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η ουρά.";
                        break;
                    }
                case 11:
                    {

                        string a = lines2.Skip(randomLineNumber + 44).First();
                        string b = lines2.Skip(randomLineNumber + 45).First();
                        string c = lines2.Skip(randomLineNumber + 46).First();
                        string d = lines2.Skip(randomLineNumber + 47).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Λικέρ.";
                        break;
                    }
                case 12:
                    {
                        string a = lines2.Skip(randomLineNumber + 48).First();
                        string b = lines2.Skip(randomLineNumber + 49).First();
                        string c = lines2.Skip(randomLineNumber + 50).First();
                        string d = lines2.Skip(randomLineNumber + 51).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Πλούτωνας.";
                        break;
                    }
                case 13:
                    {
                        string a = lines2.Skip(randomLineNumber + 52).First();
                        string b = lines2.Skip(randomLineNumber + 53).First();
                        string c = lines2.Skip(randomLineNumber + 54).First();
                        string d = lines2.Skip(randomLineNumber + 55).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Οι Ρωμαίοι.";
                        break;
                    }
                case 14:
                    {
                        string a = lines2.Skip(randomLineNumber + 56).First();
                        string b = lines2.Skip(randomLineNumber + 57).First();
                        string c = lines2.Skip(randomLineNumber + 58).First();
                        string d = lines2.Skip(randomLineNumber + 59).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "1.000.000 pixel.";
                        break;
                    }
                    
                case 15:
                    {
                        string a = lines2.Skip(randomLineNumber + 60).First();
                        string b = lines2.Skip(randomLineNumber + 61).First();
                        string c = lines2.Skip(randomLineNumber + 62).First();
                        string d = lines2.Skip(randomLineNumber + 63).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ωκεάνιες τάφροι.";
                        break;
                    }
                case 16:
                    {
                        string a = lines2.Skip(randomLineNumber + 64).First();
                        string b = lines2.Skip(randomLineNumber + 65).First();
                        string c = lines2.Skip(randomLineNumber + 66).First();
                        string d = lines2.Skip(randomLineNumber + 67).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ηράκλειο Κρήτης.";
                        break;
                    }
                case 17:
                    {
                        string a = lines2.Skip(randomLineNumber + 68).First();
                        string b = lines2.Skip(randomLineNumber + 69).First();
                        string c = lines2.Skip(randomLineNumber + 70).First();
                        string d = lines2.Skip(randomLineNumber + 71).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Οκτώ (8).";
                        break;
                    }
                case 18:
                    {
                        string a = lines2.Skip(randomLineNumber + 72).First();
                        string b = lines2.Skip(randomLineNumber + 73).First();
                        string c = lines2.Skip(randomLineNumber + 74).First();
                        string d = lines2.Skip(randomLineNumber + 75).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Άζωτο.";
                        break;
                    }
                case 19:
                    {
                        string a = lines2.Skip(randomLineNumber + 76).First();
                        string b = lines2.Skip(randomLineNumber + 77).First();
                        string c = lines2.Skip(randomLineNumber + 78).First();
                        string d = lines2.Skip(randomLineNumber + 79).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ερμής.";
                        break;
                    }
                case 20:
                    {

                        string a = lines2.Skip(randomLineNumber + 80).First();
                        string b = lines2.Skip(randomLineNumber + 81).First();
                        string c = lines2.Skip(randomLineNumber + 82).First();
                        string d = lines2.Skip(randomLineNumber + 83).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ιωνικού και Δωρικού.";
                        break;
                    }
                case 21:
                    {
                        string a = lines2.Skip(randomLineNumber + 84).First();
                        string b = lines2.Skip(randomLineNumber + 85).First();
                        string c = lines2.Skip(randomLineNumber + 86).First();
                        string d = lines2.Skip(randomLineNumber + 87).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "24 Μbps.";
                        break;
                    }
                case 22:
                    {
                        string a = lines2.Skip(randomLineNumber + 88).First();
                        string b = lines2.Skip(randomLineNumber + 89).First();
                        string c = lines2.Skip(randomLineNumber + 90).First();
                        string d = lines2.Skip(randomLineNumber + 91).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ιβουάρ.";
                        break;
                    }
                case 23:
                    {
                        string a = lines2.Skip(randomLineNumber + 92).First();
                        string b = lines2.Skip(randomLineNumber + 93).First();
                        string c = lines2.Skip(randomLineNumber + 94).First();
                        string d = lines2.Skip(randomLineNumber + 95).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Save our souls.";
                        break;
                    }
                case 24:
                    {
                        string a = lines2.Skip(randomLineNumber + 96).First();
                        string b = lines2.Skip(randomLineNumber + 97).First();
                        string c = lines2.Skip(randomLineNumber + 98).First();
                        string d = lines2.Skip(randomLineNumber + 99).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η Λιβαδειά.";
                        break;
                    }
                case 25:
                    {
                        string a = lines2.Skip(randomLineNumber + 100).First();
                        string b = lines2.Skip(randomLineNumber + 101).First();
                        string c = lines2.Skip(randomLineNumber + 102).First();
                        string d = lines2.Skip(randomLineNumber + 103).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Του Βουκουρεστίου.";
                        break;
                    }
                case 26:
                    {
                        string a = lines2.Skip(randomLineNumber + 104).First();
                        string b = lines2.Skip(randomLineNumber + 105).First();
                        string c = lines2.Skip(randomLineNumber + 106).First();
                        string d = lines2.Skip(randomLineNumber + 107).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ακουαφόρτε.";
                        break;
                    }
                case 27:
                    {
                        string a = lines2.Skip(randomLineNumber + 108).First();
                        string b = lines2.Skip(randomLineNumber + 109).First();
                        string c = lines2.Skip(randomLineNumber + 110).First();
                        string d = lines2.Skip(randomLineNumber + 111).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Παραλόγου.";
                        break;
                    }
                case 28:
                    {
                        string a = lines2.Skip(randomLineNumber + 112).First();
                        string b = lines2.Skip(randomLineNumber + 113).First();
                        string c = lines2.Skip(randomLineNumber + 114).First();
                        string d = lines2.Skip(randomLineNumber + 115).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Σκοποβολή.";
                        break;
                    }
                case 29:
                    {
                        string a = lines2.Skip(randomLineNumber + 116).First();
                        string b = lines2.Skip(randomLineNumber + 117).First();
                        string c = lines2.Skip(randomLineNumber + 118).First();
                        string d = lines2.Skip(randomLineNumber + 119).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Homegroups.";
                        break;
                    }
            }
        }

        private void ShowThirdQuestions()
        {
            switch (randomLineNumber)
            {
                case 0:
                    {
                        string a = lines2.Skip(randomLineNumber).First();
                        string b = lines2.Skip(randomLineNumber + 1).First();
                        string c = lines2.Skip(randomLineNumber + 2).First();
                        string d = lines2.Skip(randomLineNumber + 3).First();
                        ButtonAtext.Text = a; ButtonBtext.Text = b; ButtonCtext.Text = c; ButtonDtext.Text = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ελλάδα.";
                        break;
                    }
                case 1:
                    {

                        string a = lines2.Skip(randomLineNumber + 4).First();
                        string b = lines2.Skip(randomLineNumber + 5).First();
                        string c = lines2.Skip(randomLineNumber + 6).First();
                        string d = lines2.Skip(randomLineNumber + 7).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Δώσε μου κάπου να σταθώ και θα κινήσω τη Γη.";
                        break;
                    }
                case 2:
                    {
                        string a = lines2.Skip(randomLineNumber + 8).First();
                        string b = lines2.Skip(randomLineNumber + 9).First();
                        string c = lines2.Skip(randomLineNumber + 10).First();
                        string d = lines2.Skip(randomLineNumber + 11).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Αριστοτέλης.";
                        break;
                    }
                case 3:
                    {
                        string a = lines2.Skip(randomLineNumber + 12).First();
                        string b = lines2.Skip(randomLineNumber + 13).First();
                        string c = lines2.Skip(randomLineNumber + 14).First();
                        string d = lines2.Skip(randomLineNumber + 15).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ισπανός.";
                        break;
                    }
                case 4:
                    {

                        string a = lines2.Skip(randomLineNumber + 16).First();
                        string b = lines2.Skip(randomLineNumber + 17).First();
                        string c = lines2.Skip(randomLineNumber + 18).First();
                        string d = lines2.Skip(randomLineNumber + 19).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ρύζι.";
                        break;
                    }
                case 5:
                    {
                        string a = lines2.Skip(randomLineNumber + 20).First();
                        string b = lines2.Skip(randomLineNumber + 21).First();
                        string c = lines2.Skip(randomLineNumber + 22).First();
                        string d = lines2.Skip(randomLineNumber + 23).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Γαλλία.";
                        break;
                    }
                case 6:
                    {
                        string a = lines2.Skip(randomLineNumber + 24).First();
                        string b = lines2.Skip(randomLineNumber + 25).First();
                        string c = lines2.Skip(randomLineNumber + 26).First();
                        string d = lines2.Skip(randomLineNumber + 27).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Στην Καλιφόρνια.";
                        break;
                    }
                case 7:
                    {
                        string a = lines2.Skip(randomLineNumber + 28).First();
                        string b = lines2.Skip(randomLineNumber + 29).First();
                        string c = lines2.Skip(randomLineNumber + 30).First();
                        string d = lines2.Skip(randomLineNumber + 31).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Φερδινάνδος Μαγγελάνος.";
                        break;
                    }
                case 8:
                    {
                        string a = lines2.Skip(randomLineNumber + 32).First();
                        string b = lines2.Skip(randomLineNumber + 33).First();
                        string c = lines2.Skip(randomLineNumber + 34).First();
                        string d = lines2.Skip(randomLineNumber + 35).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ηρόδοτος.";
                        break;
                    }
                case 9:
                    {
                        string a = lines2.Skip(randomLineNumber + 36).First();
                        string b = lines2.Skip(randomLineNumber + 37).First();
                        string c = lines2.Skip(randomLineNumber + 38).First();
                        string d = lines2.Skip(randomLineNumber + 39).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Με το Σύνταγμα του 1975.";
                        break;
                    }

                case 10:
                    {
                        string a = lines2.Skip(randomLineNumber + 40).First();
                        string b = lines2.Skip(randomLineNumber + 41).First();
                        string c = lines2.Skip(randomLineNumber + 42).First();
                        string d = lines2.Skip(randomLineNumber + 43).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Η συνθήκη των παρισίων.";
                        break;
                    }
                case 11:
                    {

                        string a = lines2.Skip(randomLineNumber + 44).First();
                        string b = lines2.Skip(randomLineNumber + 45).First();
                        string c = lines2.Skip(randomLineNumber + 46).First();
                        string d = lines2.Skip(randomLineNumber + 47).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Μιλτιάδης.";
                        break;
                    }
                case 12:
                    {
                        string a = lines2.Skip(randomLineNumber + 48).First();
                        string b = lines2.Skip(randomLineNumber + 49).First();
                        string c = lines2.Skip(randomLineNumber + 50).First();
                        string d = lines2.Skip(randomLineNumber + 51).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ρότερνταμ.";
                        break;
                    }
                case 13:
                    {
                        string a = lines2.Skip(randomLineNumber + 52).First();
                        string b = lines2.Skip(randomLineNumber + 53).First();
                        string c = lines2.Skip(randomLineNumber + 54).First();
                        string d = lines2.Skip(randomLineNumber + 55).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Στην Κίνα.";
                        break;
                    }
                case 14:
                    {
                        string a = lines2.Skip(randomLineNumber + 56).First();
                        string b = lines2.Skip(randomLineNumber + 57).First();
                        string c = lines2.Skip(randomLineNumber + 58).First();
                        string d = lines2.Skip(randomLineNumber + 59).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Φυσικό αέριο.";
                        break;
                    }
                case 15:
                    {
                        string a = lines2.Skip(randomLineNumber + 60).First();
                        string b = lines2.Skip(randomLineNumber + 61).First();
                        string c = lines2.Skip(randomLineNumber + 62).First();
                        string d = lines2.Skip(randomLineNumber + 63).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Διώριγα του Σουέζ.";
                        break;
                    }
                case 16:
                    {
                        string a = lines2.Skip(randomLineNumber + 64).First();
                        string b = lines2.Skip(randomLineNumber + 65).First();
                        string c = lines2.Skip(randomLineNumber + 66).First();
                        string d = lines2.Skip(randomLineNumber + 67).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ιταλίας.";
                        break;
                    }
                case 17:
                    {
                        string a = lines2.Skip(randomLineNumber + 68).First();
                        string b = lines2.Skip(randomLineNumber + 69).First();
                        string c = lines2.Skip(randomLineNumber + 70).First();
                        string d = lines2.Skip(randomLineNumber + 71).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Άνδεις.";
                        break;
                    }
                case 18:
                    {
                        string a = lines2.Skip(randomLineNumber + 72).First();
                        string b = lines2.Skip(randomLineNumber + 73).First();
                        string c = lines2.Skip(randomLineNumber + 74).First();
                        string d = lines2.Skip(randomLineNumber + 75).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Βαικάλη.";
                        break;
                    }
                case 19:
                    {
                        string a = lines2.Skip(randomLineNumber + 76).First();
                        string b = lines2.Skip(randomLineNumber + 77).First();
                        string c = lines2.Skip(randomLineNumber + 78).First();
                        string d = lines2.Skip(randomLineNumber + 79).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Νικόλαος Μάντζαρος.";
                        break;
                    }
                case 20:
                    {
                        string a = lines2.Skip(randomLineNumber + 80).First();
                        string b = lines2.Skip(randomLineNumber + 81).First();
                        string c = lines2.Skip(randomLineNumber + 82).First();
                        string d = lines2.Skip(randomLineNumber + 83).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ποινικό δικαστήριο.";
                        break;
                    }
                case 21:
                    {
                        string a = lines2.Skip(randomLineNumber + 84).First();
                        string b = lines2.Skip(randomLineNumber + 85).First();
                        string c = lines2.Skip(randomLineNumber + 86).First();
                        string d = lines2.Skip(randomLineNumber + 87).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Το πταίσμα.";
                        break;
                    }
                case 22:
                    {
                        string a = lines2.Skip(randomLineNumber + 88).First();
                        string b = lines2.Skip(randomLineNumber + 89).First();
                        string c = lines2.Skip(randomLineNumber + 90).First();
                        string d = lines2.Skip(randomLineNumber + 91).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Ειδωλολάτρης.";
                        break;
                    }
                case 23:
                    {
                        string a = lines2.Skip(randomLineNumber + 92).First();
                        string b = lines2.Skip(randomLineNumber + 93).First();
                        string c = lines2.Skip(randomLineNumber + 94).First();
                        string d = lines2.Skip(randomLineNumber + 95).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Mε τους κρατούμενους συνείδησης.";
                        break;
                    }
                case 24:
                    {

                        string a = lines2.Skip(randomLineNumber + 96).First();
                        string b = lines2.Skip(randomLineNumber + 97).First();
                        string c = lines2.Skip(randomLineNumber + 98).First();
                        string d = lines2.Skip(randomLineNumber + 99).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Φήμιος.";
                        break;
                    }
                case 25:
                    {
                        string a = lines2.Skip(randomLineNumber + 100).First();
                        string b = lines2.Skip(randomLineNumber + 101).First();
                        string c = lines2.Skip(randomLineNumber + 102).First();
                        string d = lines2.Skip(randomLineNumber + 103).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Άζωτο.";
                        break;
                    }
                case 26:
                    {
                        string a = lines2.Skip(randomLineNumber + 104).First();
                        string b = lines2.Skip(randomLineNumber + 105).First();
                        string c = lines2.Skip(randomLineNumber + 106).First();
                        string d = lines2.Skip(randomLineNumber + 107).First();
                        first = a; second = b; third = c; fourth = d;
                        tuxaia_seira();
                        CorrectAnswer = "Εκκλησιαστικό δικαστήριο. ";
                        break;
                    }
            }
        }

        // Μπερδευει τις απαντησεις με τα κουμπια!
        public void tuxaia_seira()
        {
            string[] nums = new string[4];
            nums[0] = first;
            nums[1] = second;
            nums[2] = third;
            nums[3] = fourth;
            Random rand = new Random();
            while (true)
            {
                w = rand.Next(0, 4);
                y = rand.Next(0, 4);
                z = rand.Next(0, 4);
                k = rand.Next(0, 4);
                if (w != y && w != z && w != k && y != z && y != k && k != z)
                { break; }
            }
            ButtonAtext.Text = nums[w];
            this.mQuestionsView.Text = lines[randomLineNumber];
            ButtonBtext.Text = nums[y];
            this.mQuestionsView.Text = lines[randomLineNumber];
            ButtonCtext.Text = nums[z];
            this.mQuestionsView.Text = lines[randomLineNumber];
            ButtonDtext.Text = nums[k];
            this.mQuestionsView.Text = lines[randomLineNumber];
        }

        // Η βοηθεια 50-50
        private void MHalf_Half_Click(object sender, EventArgs e)
        {
            MediaPlayer _Half = MediaPlayer.Create(this, Resource.Raw.half_half_sound);
            _Half.Start();
            if (CorrectAnswer == ButtonAtext.Text)
            {
                Random r = new Random();
                List<string> epilogh = new List<string>(3) { ButtonBtext.Text, ButtonCtext.Text, ButtonDtext.Text };
                string tuxaio;
                for (int y = 0; y < 2; ++y)
                {
                        tuxaio = epilogh[r.Next(0, 2)].ToString();
                        epilogh.Remove(tuxaio);
                            if (tuxaio == ButtonBtext.Text)
                            {
                                ButtonBtext.Text = "";
                                ButtonBtext.Clickable = false;
                                ButtonB.Clickable = false;
                                ButtonB1.Clickable = false;
                                ButtonB2.Clickable = false;
                            }
                            else if (tuxaio == ButtonCtext.Text)
                            {
                                ButtonCtext.Text = "";
                                ButtonCtext.Clickable = false;
                                ButtonC.Clickable = false;
                                ButtonC1.Clickable = false;
                                ButtonC2.Clickable = false;
                            }
                            else if (tuxaio == ButtonDtext.Text)
                            {
                                ButtonDtext.Text = "";
                                ButtonDtext.Clickable = false;
                                ButtonD.Clickable = false;
                                ButtonD1.Clickable = false;
                                ButtonD2.Clickable = false;
                            }
                }
            }
            else if (CorrectAnswer == ButtonBtext.Text)
            {
                Random r = new Random();
                List<string> epilogh = new List<string>(3) { ButtonAtext.Text, ButtonCtext.Text, ButtonDtext.Text };
                string tuxaio;
                for (int y = 0; y < 2; ++y)
                {
                        tuxaio = epilogh[r.Next(0, 2)].ToString();
                        epilogh.Remove(tuxaio);
                        if (tuxaio == ButtonAtext.Text)
                            {
                                ButtonAtext.Text = "";
                                ButtonAtext.Clickable = false;
                                ButtonA.Clickable = false;
                                ButtonA1.Clickable = false;
                                ButtonA2.Clickable = false;
                            }
                            else if (tuxaio == ButtonCtext.Text)
                            {
                                ButtonCtext.Text = "";
                                ButtonCtext.Clickable = false;
                                ButtonC.Clickable = false;
                                ButtonC1.Clickable = false;
                                ButtonC2.Clickable = false;
                            }
                            else if (tuxaio == ButtonDtext.Text)
                            {
                                ButtonDtext.Text = "";
                                ButtonDtext.Clickable = false;
                                ButtonD.Clickable = false;
                                ButtonD1.Clickable = false;
                                ButtonD2.Clickable = false;
                            }
                }
            }
            else if (CorrectAnswer == ButtonCtext.Text)
            {
                Random r = new Random();
                List<string> epilogh = new List<string>(3) { ButtonAtext.Text, ButtonBtext.Text, ButtonDtext.Text };
                string tuxaio;
                for (int y = 0; y < 2; ++y)
                {
                        tuxaio = epilogh[r.Next(0, 2)].ToString();
                        epilogh.Remove(tuxaio);
                        if (tuxaio == ButtonBtext.Text)
                            {
                                ButtonBtext.Text = "";
                                ButtonBtext.Clickable = false;
                                ButtonB.Clickable = false;
                                ButtonB1.Clickable = false;
                                ButtonB2.Clickable = false;
                            }
                            else if (tuxaio == ButtonAtext.Text)
                            {
                                ButtonAtext.Text = "";
                                ButtonAtext.Clickable = false;
                                ButtonA.Clickable = false;
                                ButtonA1.Clickable = false;
                                ButtonA2.Clickable = false;
                            }
                            else if (tuxaio == ButtonDtext.Text)
                            {
                                ButtonDtext.Text = "";
                                ButtonDtext.Clickable = false;
                                ButtonD.Clickable = false;
                                ButtonD1.Clickable = false;
                                ButtonD2.Clickable = false;
                            }
                }
            }
            else if (CorrectAnswer == ButtonDtext.Text)
            {
                Random r = new Random();
                List<string> epilogh = new List<string>(3) { ButtonAtext.Text, ButtonBtext.Text, ButtonCtext.Text };
                string tuxaio;
                for (int y = 0; y < 2; ++y)
                {
                        tuxaio = epilogh[r.Next(0, 2)].ToString();
                        epilogh.Remove(tuxaio);
                            if (tuxaio == ButtonBtext.Text)
                            {
                                ButtonBtext.Text = "";
                                ButtonBtext.Clickable = false;
                                ButtonB.Clickable = false;
                                ButtonB1.Clickable = false;
                                ButtonB2.Clickable = false;
                            }
                            else if (tuxaio == ButtonCtext.Text)
                            {
                                ButtonCtext.Text = "";
                                ButtonCtext.Clickable = false;
                                ButtonC.Clickable = false;
                                ButtonC1.Clickable = false;
                                ButtonC2.Clickable = false;
                            }
                            else if (tuxaio == ButtonAtext.Text)
                            {
                                ButtonAtext.Text = "";
                                ButtonAtext.Clickable = false;
                                ButtonA.Clickable = false;
                                ButtonA1.Clickable = false;
                                ButtonA2.Clickable = false;
                            }
                }
            }
            mHalf_Half.SetBackgroundResource(Resource.Drawable.disable_half);
            mHalf_Half.Enabled = false;
        }

        private void MPhone_Click(object sender, EventArgs e)
        {
            //BackgroundMusic.Pause();
            if (score <= 5)
            {
                int value = r.Next(1, 3);
                if (CorrectAnswer == ButtonAtext.Text)
                {
                    if (value == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A1);
                                      _Phone.Start(); }
                    else if (value == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A2);
                                           _Phone.Start(); }
                    else if (value == 3) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A4);
                                            _Phone.Start(); }
                }
                else if (CorrectAnswer == ButtonBtext.Text)
                {
                    if (value == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B1);
                                      _Phone.Start(); }
                    else if (value == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B3);
                                           _Phone.Start(); }
                    else if (value == 3) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B4);
                                           _Phone.Start(); }
                }
                else if (CorrectAnswer == ButtonCtext.Text)
                {
                    if (value == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C1);
                                      _Phone.Start(); }
                    else if (value == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C2);
                                           _Phone.Start(); }
                    else if (value == 3) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C4);
                                           _Phone.Start(); }
                }
                else if (CorrectAnswer == ButtonDtext.Text)
                {
                    if (value == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D1);
                                      _Phone.Start(); }
                    else if (value == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D3);
                                           _Phone.Start(); }
                    else if (value == 3) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D4);
                                           _Phone.Start(); }
                }
            }
            else if (score > 5 && score <= 10)
            {
                int value2 = r.Next(1, 2);
                if (CorrectAnswer == ButtonAtext.Text)
                {
                    if (value2 == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A1);
                                       _Phone.Start(); }
                    else if (value2 == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A2);
                                            _Phone.Start();}
                }
                else if (CorrectAnswer == ButtonBtext.Text)
                {
                    if (value2 == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B4);
                                       _Phone.Start(); }
                    else if (value2 == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B3);
                                            _Phone.Start(); }
                }
                else if (CorrectAnswer == ButtonCtext.Text)
                {
                    if (value2 == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C1);
                                       _Phone.Start(); }
                    else if (value2 == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C2);
                                            _Phone.Start(); }
                }
                else if (CorrectAnswer == ButtonDtext.Text)
                {
                    if (value2 == 1) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D4);
                                       _Phone.Start(); }
                    else if (value2 == 2) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D3);
                                            _Phone.Start(); }
                }
            }
            else if (score > 10)
            {
                if (CorrectAnswer == ButtonAtext.Text) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_A3);
                                                         _Phone.Start(); }
                else if (CorrectAnswer == ButtonBtext.Text) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_B2);
                                                              _Phone.Start(); }
                else if (CorrectAnswer == ButtonCtext.Text) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_C3);
                                                              _Phone.Start(); }
                else if (CorrectAnswer == ButtonDtext.Text) { _Phone = MediaPlayer.Create(this, Resource.Raw.Phone_D2);
                                                              _Phone.Start(); }
            }
            mPhone.SetBackgroundResource(Resource.Drawable.disable_phone);
            mPhone.Enabled = false;
            //BackgroundMusic.Start();
        }

        public void MAudience_ClickAsync(object sender, EventArgs e)
        {
            //BackgroundMusic.Pause();
            Random rnd = new Random();
            double a = rnd.Next(0, 100);
            double b = rnd.Next(0, 100);
            double c = rnd.Next(0, 100);
            double d = rnd.Next(0, 100);

            perc = (a + b + c + d) / 100;

            a /= perc;
            b /= perc;
            c /= perc;
            d /= perc;

            alpha = (int)a;
            beta = (int)b;
            gamma = (int)c;
            delta = (int)d;

            Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();

            if (ButtonAtext.Text == CorrectAnswer)
            {
                if (alpha > beta && alpha > gamma && alpha > delta)
                {
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                    
                }
                else if (beta > alpha && beta > gamma && beta > delta)
                {
                    biggestNum = beta;
                    alpha = beta;
                    beta = alpha;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (gamma > alpha && gamma > beta && gamma > delta)
                {
                    biggestNum = gamma;
                    gamma = alpha;
                    alpha = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else
                {
                    biggestNum = delta;
                    delta = alpha;
                    alpha = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
            }
            else if (ButtonBtext.Text == CorrectAnswer)
            {
                if (alpha > beta && alpha > gamma && alpha > delta)
                {
                    biggestNum = alpha;
                    alpha = beta;
                    beta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");  
                }
                else if (beta > alpha && beta > gamma && beta > delta)
                {
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (gamma > alpha && gamma > beta && gamma > delta)
                {
                    biggestNum = gamma;
                    gamma = beta;
                    beta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else
                {
                    biggestNum = delta;
                    delta = beta;
                    beta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
            }
            else if (ButtonCtext.Text == CorrectAnswer)
            {
                if (alpha > beta && alpha > gamma && alpha > delta)
                {
                    biggestNum = alpha;
                    alpha = gamma;
                    gamma = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (beta > alpha && beta > gamma && beta > delta)
                {
                    biggestNum = beta;
                    beta = gamma;
                    gamma = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (gamma > alpha && gamma > beta && gamma > delta)
                {
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else
                {
                    biggestNum = delta;
                    delta = gamma;
                    gamma = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
            }
            else if (ButtonDtext.Text == CorrectAnswer)
            {
                if (alpha > beta && alpha > gamma && alpha > delta)
                {
                    biggestNum = alpha;
                    alpha = delta;
                    delta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (beta > alpha && beta > gamma && beta > delta)
                {
                    biggestNum = beta;
                    beta = delta;
                    delta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else if (gamma > alpha && gamma > beta && gamma > delta)
                {
                    biggestNum = gamma;
                    gamma = delta;
                    delta = biggestNum;
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
                else
                {
                    AudienceActivity audience = new AudienceActivity(alpha, beta, gamma, delta);
                    audience.Show(fragment, "Dialog Fragment");
                }
            }
            mAudience.SetBackgroundResource(Resource.Drawable.disable_audience);
            mAudience.Enabled = false;
            //BackgroundMusic.Start();
        }

        // Κουμπι Α
        private async void ButtonA_ClickAsync(object sender, EventArgs e)
        {
            DisableButtonClicks();
            //BackgroundMusic.Pause();
            if (ButtonAtext.Text == CorrectAnswer)
            {
                ResetTimer();
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Correct_Answer();
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                await Task.Delay(1500);
                if (score == 14)
                {
                    ButtonAtext.Clickable = false;
                    ButtonA.Clickable = false;
                    ButtonA1.Clickable = false;
                    ButtonA2.Clickable = false;
                    ButtonBtext.Clickable = false;
                    ButtonB.Clickable = false;
                    ButtonB1.Clickable = false;
                    ButtonB2.Clickable = false;
                    ButtonCtext.Clickable = false;
                    ButtonC.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonDtext.Clickable = false;
                    ButtonD.Clickable = false;
                    ButtonD1.Clickable = false;
                    ButtonD2.Clickable = false;
                }
                score++;
                ScoreTable();
                if (score == 6) {
                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score == 11)
                {

                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score < 14) { NextQuestion(); }
                else
                {
                    Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                    WinGameActivity popupWindow = new WinGameActivity();
                    popupWindow.Show(fragment, "Dialog Fragment");

                    MediaPlayer million = MediaPlayer.Create(this, Resource.Raw.milllionaire_Win);
                    million.Start();
                }
            }
            else
            {
                _timer.Stop();
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Wrong_Answer();
                ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                if (ButtonBtext.Text == CorrectAnswer)
                {
                    ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonCtext.Text == CorrectAnswer)
                {
                    ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonDtext.Text == CorrectAnswer)
                {
                    ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                await Task.Delay(2000);
                FinalScore();
                await Task.Delay(5000);
            }
        }

        //Κουμπι Β
        private async void ButtonB_Click(object sender, EventArgs e)
        {
            DisableButtonClicks();
            //BackgroundMusic.Pause();
            if (ButtonBtext.Text == CorrectAnswer)
            {
                ResetTimer();
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Correct_Answer();
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                await Task.Delay(1500);
                if (score == 14)
                {
                    ButtonAtext.Clickable = false;
                    ButtonA.Clickable = false;
                    ButtonA1.Clickable = false;
                    ButtonA2.Clickable = false;
                    ButtonBtext.Clickable = false;
                    ButtonB.Clickable = false;
                    ButtonB1.Clickable = false;
                    ButtonB2.Clickable = false;
                    ButtonCtext.Clickable = false;
                    ButtonC.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonDtext.Clickable = false;
                    ButtonD.Clickable = false;
                    ButtonD1.Clickable = false;
                    ButtonD2.Clickable = false;
                }
                score++;
                ScoreTable();
                if (score == 6) {
                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score == 11)
                {

                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score < 14) { NextQuestion(); }
                else
                {
                    Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                    WinGameActivity popupWindow = new WinGameActivity();
                    popupWindow.Show(fragment, "Dialog Fragment");

                    MediaPlayer million = MediaPlayer.Create(this, Resource.Raw.milllionaire_Win);
                    million.Start();
                }
            }
            else
            {
                _timer.Stop();
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Wrong_Answer();
                ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                if (ButtonAtext.Text == CorrectAnswer)
                {
                    ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonCtext.Text == CorrectAnswer)
                {
                    ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonDtext.Text == CorrectAnswer)
                {
                    ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                await Task.Delay(2000);
                FinalScore();
                await Task.Delay(5000);
            }
        }

        // Κουμπι Γ
        private async void ButtonC_Click(object sender, EventArgs e)
        {
            DisableButtonClicks();
            //BackgroundMusic.Pause();
            if (ButtonCtext.Text == CorrectAnswer)
            {
                ResetTimer();
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Correct_Answer();
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                await Task.Delay(1500);
                if (score == 14)
                {
                    ButtonAtext.Clickable = false;
                    ButtonA.Clickable = false;
                    ButtonA1.Clickable = false;
                    ButtonA2.Clickable = false;
                    ButtonBtext.Clickable = false;
                    ButtonB.Clickable = false;
                    ButtonB1.Clickable = false;
                    ButtonB2.Clickable = false;
                    ButtonCtext.Clickable = false;
                    ButtonC.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonDtext.Clickable = false;
                    ButtonD.Clickable = false;
                    ButtonD1.Clickable = false;
                    ButtonD2.Clickable = false;
                }
                score++;
                ScoreTable();
                if (score == 6)
                {
                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score == 11)
                {

                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score < 14) { NextQuestion(); }
                else
                {
                    Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                    WinGameActivity popupWindow = new WinGameActivity();
                    popupWindow.Show(fragment, "Dialog Fragment");

                    MediaPlayer million = MediaPlayer.Create(this, Resource.Raw.milllionaire_Win);
                    million.Start();
                }
            }
            else
            {
                _timer.Stop();
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Wrong_Answer();
                ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                if (ButtonAtext.Text == CorrectAnswer)
                {
                    ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonBtext.Text == CorrectAnswer)
                {
                    ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonDtext.Text == CorrectAnswer)
                {
                    ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                await Task.Delay(2000);
                FinalScore();
                await Task.Delay(5000);
            }
        }

        // Κουμπι Δ
        private async void ButtonD_Click(object sender, EventArgs e)
        {
            DisableButtonClicks();
            //BackgroundMusic.Pause();
            if (ButtonDtext.Text == CorrectAnswer)
            {
                ResetTimer();
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Correct_Answer();
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                await Task.Delay(1500);
                if (score == 14)
                {
                    ButtonAtext.Clickable = false;
                    ButtonA.Clickable = false;
                    ButtonA1.Clickable = false;
                    ButtonA2.Clickable = false;
                    ButtonBtext.Clickable = false;
                    ButtonB.Clickable = false;
                    ButtonB1.Clickable = false;
                    ButtonB2.Clickable = false;
                    ButtonCtext.Clickable = false;
                    ButtonC.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonC1.Clickable = false;
                    ButtonDtext.Clickable = false;
                    ButtonD.Clickable = false;
                    ButtonD1.Clickable = false;
                    ButtonD2.Clickable = false;
                }
                score++;
                ScoreTable();
                if (score == 6 )
                {
                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if(score == 11)
                {

                    if (CrossConnectivity.Current.IsConnected == true)
                    {
                        AdsEnable();
                    }
                    else
                    {
                        NextQuestion();
                    }
                }
                else if (score < 14) { NextQuestion(); }
                else
                {
                    Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
                    WinGameActivity popupWindow = new WinGameActivity();
                    popupWindow.Show(fragment, "Dialog Fragment");

                    MediaPlayer million = MediaPlayer.Create(this, Resource.Raw.milllionaire_Win);
                    million.Start();
                }
            }
            else
            {
                _timer.Stop();
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(700);
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff00"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_yellow);
                await Task.Delay(700);
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_orange);
                await Task.Delay(1000);
                Wrong_Answer();
                ButtonD.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                ButtonD1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonDtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff3300"));
                ButtonD2.SetBackgroundResource(Resource.Drawable.arrow_up_red);
                if (ButtonAtext.Text == CorrectAnswer)
                {
                    ButtonA.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonA1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonAtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonA2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonBtext.Text == CorrectAnswer)
                {
                    ButtonB.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonB1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonBtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonB2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                else if (ButtonCtext.Text == CorrectAnswer)
                {
                    ButtonC.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                    ButtonC1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonCtext.SetBackgroundColor(Android.Graphics.Color.ParseColor("#00cc00"));
                    ButtonC2.SetBackgroundResource(Resource.Drawable.arrow_up_green);
                }
                await Task.Delay(5000);
                FinalScore();
                await Task.Delay(5000);
            }
        }

        private void RandomNumber()
        {
            randomLineNumber = r.Next(0, lines.Length - 1);
        }


        private void AdsEnable()
        {
            if (this.mInterstitialAd.IsLoaded)
            {
                this.mInterstitialAd.Show();
            }
            else
            {
                RequestNewInterstitial();
            }
        }

        // Προσωρινά απενεργοποιεί το πάτημα των κουμπιών
        private void DisableButtonClicks()
        {

            mHalf_Half.Clickable = false;
            mAudience.Clickable = false;
            mPhone.Clickable = false;

            ButtonA.Clickable = false;
            ButtonAtext.Clickable = false;
            ButtonA1.Clickable = false;
            ButtonA2.Clickable = false;
            ButtonB.Clickable = false;
            ButtonBtext.Clickable = false;
            ButtonB1.Clickable = false;
            ButtonB2.Clickable = false;
            ButtonC.Clickable = false;
            ButtonCtext.Clickable = false;
            ButtonC1.Clickable = false;
            ButtonC2.Clickable = false;
            ButtonD.Clickable = false;
            ButtonDtext.Clickable = false;
            ButtonD1.Clickable = false;
            ButtonD2.Clickable = false;
        }

        // Ήχοι για την σωστή απάντηση
        private void Correct_Answer()
        {
            if (score <= 5)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Correct_Answer_1);
                _player.Start();
            }
            else if (score > 5 && score <= 10)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Correct_Answer_2);
                _player.Start();
            }
            else if (score > 10 && score <= 13)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Correct_Answer_3);
                _player.Start();
            }
            else if(score == 14)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.correct_answer_win1million);
                _player.Start();
            }
        }

        // Ήχοι για την λάθος απάντηση
        private async void Wrong_Answer()
        {
            if (score <= 5)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Wrong_Answer_1);
                _player.Start();
            }
            else if (score > 5 && score <= 10)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Wrong_Answer_2);
                _player.Start();
            }
            else if (score > 10 && score <= 13)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Wrong_Answer_3);
                _player.Start();
            }
            await Task.Delay(9000);
            Android.App.FragmentTransaction fragment = FragmentManager.BeginTransaction();
            RestartGameActivity popupWindow = new RestartGameActivity();
            popupWindow.Show(fragment, "Dialog Fragment");
        }

        // Ήχος με τα ποσα κερδισε ο παιχτης.
        public void FinalScore()
        {
            if (score < 5)
            {
                _ScoreSound = MediaPlayer.Create(this, Resource.Raw.score_100);
                _ScoreSound.Start();
            }
            else if (score >= 5 && score < 10)
            {
                _ScoreSound = MediaPlayer.Create(this, Resource.Raw.score_2000);
                _ScoreSound.Start();
            }
            else if (score >= 10 && score <= 13)
            {
                _ScoreSound = MediaPlayer.Create(this, Resource.Raw.score_64000);
                _ScoreSound.Start();
            }
            else
            {
                _ScoreSound = MediaPlayer.Create(this, Resource.Raw.win_million);
                _ScoreSound.Start();
            }
        }

        // Κουμπί που ανοίγει/κλείνει την μουσική
        private void MRightImage_Click(object sender, EventArgs e)
        {
           if(musicStatus == true)
            {
                mRightImage.SetBackgroundResource(Resource.Drawable.mute);

                var audioManager = (AudioManager)GetSystemService(Context.AudioService);
                var mute = 0;
                audioManager.SetStreamVolume(Android.Media.Stream.Music, mute, 0);
                musicStatus = false;
            }
            else if (musicStatus == false)
            {
                var audioManager = (AudioManager)GetSystemService(Context.AudioService);
                var mute = 10;
                audioManager.SetStreamVolume(Android.Media.Stream.Music, mute, 0);
                mRightImage.SetBackgroundResource(Resource.Drawable.unmute);
                musicStatus = true;
            }
        }

        //Η μουσικη που παίζει στο παρασκήνιο
        //private void BackgroundMusicPlay()
        //{
        //    if (score <= 5)
        //    {
        //        BackgroundMusic = MediaPlayer.Create(this, Resource.Raw.level_1);
        //        BackgroundMusic.Start();
        //    }
        //    else if (score > 5 && score <= 10)
        //    {
        //        BackgroundMusic = MediaPlayer.Create(this, Resource.Raw.level_2);
        //        BackgroundMusic.Start();
        //    }
        //    else if (score > 10 && score <= 13)
        //    {
        //        BackgroundMusic = MediaPlayer.Create(this, Resource.Raw.level_3);
        //        BackgroundMusic.Start();
        //    }
        //}

        // Method για το score
        private void ScoreTable()
        {
            ResetColorOfScore();

            if(score == 2) { mText300.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                             mTextOfScore.Text = "300€"; }
            else if (score == 3) { mText500.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "500€"; }
            else if (score == 4) { mText1000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "1.000€"; }
            else if (score == 5) { mText2000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "2.000€"; }
            else if (score == 6) { mText4000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "4.000€"; }
            else if (score == 7) { mText8000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "8.000€"; }
            else if (score == 8) { mText16000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "16.000€"; }
            else if (score == 9) { mText32000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                   mTextOfScore.Text = "32.000€"; }
            else if (score == 10) { mText64000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                    mTextOfScore.Text = "64.000€"; }
            else if (score == 11) { mText125000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                    mTextOfScore.Text = "125.000€"; }
            else if (score == 12) { mText250000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                    mTextOfScore.Text = "250.000€"; }
            else if (score == 13) { mText500000.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                    mTextOfScore.Text = "500.000€"; }
            else if (score == 14) { mTextMillion.SetBackgroundColor(Android.Graphics.Color.ParseColor("#D84315"));
                                    mTextOfScore.Text = "1.000.000€"; }
        }

        //Επαναφορά χρωμάτων του δεξιού πίνακα
        private void ResetColorOfScore()
        {
            mText100.SetBackgroundResource(Resource.Drawable.myButton);
            mText300.SetBackgroundResource(Resource.Drawable.myButton);
            mText500.SetBackgroundResource(Resource.Drawable.myButton);
            mText1000.SetBackgroundResource(Resource.Drawable.myButton);
            mText2000.SetBackgroundResource(Resource.Drawable.myButton);
            mText4000.SetBackgroundResource(Resource.Drawable.myButton);
            mText8000.SetBackgroundResource(Resource.Drawable.myButton);
            mText16000.SetBackgroundResource(Resource.Drawable.myButton);
            mText32000.SetBackgroundResource(Resource.Drawable.myButton);
            mText64000.SetBackgroundResource(Resource.Drawable.myButton);
            mText125000.SetBackgroundResource(Resource.Drawable.myButton);
            mText250000.SetBackgroundResource(Resource.Drawable.myButton);
            mText500000.SetBackgroundResource(Resource.Drawable.myButton);
            mTextMillion.SetBackgroundResource(Resource.Drawable.myButton);
        }

        // επαναφορα ρολογιου
        private void ResetTimer()
        {
            _timer.Enabled = false;
            _timer.AutoReset = true;
            count = 30;
        }
    }
}