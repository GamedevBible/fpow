using Android.App;
using Android.Support.V7.App;
using Android.OS;
using Android.Content;
using Android.Widget;
using System;
using Microsoft.AppCenter.Analytics;
using Java.Util;

namespace FPOW.Droid
{
    [Activity(Label = "MoreGamesActivity", Theme = "@style/AppTheme.Main",
        Icon = "@mipmap/ic_launcher")]
    public class MoreGamesActivity : AppCompatActivity
    {
        private TextView _bmTextView;
        private TextView _bmTitleTextView;
        private Button _bmButton;

        private TextView _bwTextView;
        private TextView _bwTitleTextView;
        private Button _bwButton;

        private const string _bmPackageName = "com.BM.Droid";
        private const string _bwPackageName = "com.biblegamedev.bw";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.more_games);

            _bmTextView = FindViewById<TextView>(Resource.Id.bmtext);
            _bmTitleTextView = FindViewById<TextView>(Resource.Id.bmtitletext);
            _bmButton = FindViewById<Button>(Resource.Id.bmButton);
            _bwTextView = FindViewById<TextView>(Resource.Id.bwtext);
            _bwTitleTextView = FindViewById<TextView>(Resource.Id.bwtitletext);
            _bwButton = FindViewById<Button>(Resource.Id.bwButton);
            _bmButton.Click += OnBmClicked;
            _bwButton.Click += OnBwClicked;

            var lang = Locale.Default.Language;

            _bwButton.Text = _bmButton.Text = lang == "ru" ? "Перейти к игре" : "Go to game";
            _bmTitleTextView.Text = lang == "ru" ? "Миллионер - Библия" : "Bible Millionaire (only russian language now)";
            _bmTextView.Text = "Игра, в которой вам предстоит выбрать один из четырех представленных ответов на вопросы по Библии." + "\n" +
                "Попробуйте дойти до самого конца и выиграть миллион очков!" + "\n" +
                "В игре вас ждет более 3000 вопросов!";
            _bmTextView.Visibility = lang == "ru" ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;

            _bwTitleTextView.Text = lang == "ru" 
                ? "Библейские слова" 
                : lang == "es" 
                    ? "Palabras de la Biblia" 
                    : "Bible words";
            _bwTextView.Text = "Игра, в которой вам предстоит отгадать, какое слово из выбранной вами категории загадано." + "\n" +
                "У вас есть несколько попыток угадать слово, пока мост не разрушился!" + "\n" + "В игре можно загадывать слово другу и играть с ним на одном устройстве!" + "\n" +
                "В игре также постепенно будут добавляться новые уровни!";
            _bwTextView.Visibility = lang == "ru" ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
        }

        private void OnBwClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("User go to BW from FPOW");

            try
            {
                StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + _bwPackageName)));
            }
            catch (ActivityNotFoundException anfe)
            {
                StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id=" + _bwPackageName)));
            }
        }

        private void OnBmClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("User go to BM from FPOW");

            try
            {
                StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=" + _bmPackageName)));
            }
            catch (ActivityNotFoundException anfe)
            {
                StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id=" + _bmPackageName)));
            }
        }

        public static Intent CreateStartIntent(Context context, string message = null)
        {
            var intent = new Intent(context, typeof(MoreGamesActivity));

            return intent;
        }
    }
}