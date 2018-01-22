using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Text;
using Microsoft.Azure.Mobile.Analytics;
using Java.Util;
using Android.Content.Res;
using FPOW.Droid.GameClasses;

namespace FPOW.Droid
{
    [Activity(Label = "ContactsActivity", Theme = "@style/AppTheme.Main", Icon = "@drawable/icon")]
    public class ContactsActivity : AppCompatActivity
    {
        private PreferencesHelper _preferencesHelper;
        private TextView _version;
        private TextView _lessons;
        private TextView _contactUs;
        private TextView _supportUs;
        private const int _emailRequestCode = 11234;
        private ImageButton _thanksButton;
        private bool _inactive;

        private View _lessonsLayout;
        private View _contactUsLayout;
        private View _supportUsLayout;
        private bool _languageChanged;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.contacts);

            _preferencesHelper = new PreferencesHelper();
            _preferencesHelper.InitHepler(this);

            _version = FindViewById<TextView>(Resource.Id.appVersion);
            _lessons = FindViewById<TextView>(Resource.Id.lessons);
            _contactUs = FindViewById<TextView>(Resource.Id.contactUs);
            _supportUs = FindViewById<TextView>(Resource.Id.supportUs);
            _thanksButton = FindViewById<ImageButton>(Resource.Id.thanksButton);

            _lessonsLayout = FindViewById<View>(Resource.Id.lessonsLayout);
            _contactUsLayout = FindViewById<View>(Resource.Id.contactUsLayout);
            _supportUsLayout = FindViewById<View>(Resource.Id.supportUsLayout);

            _version.Text = $"Версия приложения {PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName}";
            
            _thanksButton.Click += OnThanksButtonClicked;

            //if Landscape
            if (WindowManager.DefaultDisplay.Rotation == SurfaceOrientation.Rotation90 || WindowManager.DefaultDisplay.Rotation == SurfaceOrientation.Rotation270)
            {
                string text = "<font>У вас есть вопросы или предложения? </font>" +
                "<font>Напишите нам: </font><font color=#01A7F2>biblegamedev@gmail.com</font>";

                _contactUs.SetText(Html.FromHtml(text), TextView.BufferType.Spannable);
            }
            else
            {
                string text = "<font>У вас есть вопросы или предложения?</font><br>" +
                "<font>Напишите нам: </font><font color=#00c853>biblegamedev@gmail.com</font>";

                _contactUs.SetText(Html.FromHtml(text), TextView.BufferType.Spannable);
            }

            var selectedLocaleIndex = _preferencesHelper.GetSelectedLanguage();
            if (selectedLocaleIndex != 0)
            {
                switch (selectedLocaleIndex)
                {
                    case 1:
                        _lessons.Text = "Language: English";
                        break;
                    case 2:
                        _lessons.Text = "Язык: Русский";
                        break;
                    case 3:
                        _lessons.Text = "Idioma: Español";
                        break;
                }
            }
            else
            {
                var currentLocale = Locale.Default;
                var enLocale = new Locale("en");
                var ruLocale = new Locale("ru");
                var esLocale = new Locale("es");

                if (currentLocale.Language == enLocale.Language)
                    _lessons.Text = "Language: English";
                if (currentLocale.Language == ruLocale.Language)
                    _lessons.Text = "Язык: Русский";
                if (currentLocale.Language == esLocale.Language)
                    _lessons.Text = "Idioma: Español";
            }

            _supportUs.Text = Resources.GetString(Resource.String.SupportUsTitle);

            _lessonsLayout.Click += OnAppVersionClicked;
            _contactUsLayout.Click += OnContactUsClicked;
            _contactUsLayout.LongClick += OnContactUsLongClicked;
            _supportUsLayout.Click += OnSupportUsClicked;
        }

        private void OnAppVersionClicked(object sender, EventArgs e)
        {
            if (_inactive)
                return;
            _inactive = true;

            new Android.Support.V7.App.AlertDialog.Builder(this)
               .SetItems(new[] { "English", "Русский", "Español" }, DialogClickHandler)
                .Show();
        }

        private void DialogClickHandler(object sender, DialogClickEventArgs e)
        {
            var currentLocale = Locale.Default;

            switch (e.Which)
            {
                case 0:
                    var enLocale = new Locale("en");
                    if (currentLocale == enLocale)
                        return;
                    _languageChanged = true;
                    _preferencesHelper.PutSelectedLanguage(this, 1);
                    Locale.Default = enLocale;
                    var config = new Configuration { Locale = enLocale };
                    BaseContext.Resources.UpdateConfiguration(config, BaseContext.Resources.DisplayMetrics);
                    break;
                case 1:
                    var ruLocale = new Locale("ru");
                    if (currentLocale == ruLocale)
                        return;
                    _languageChanged = true;
                    _preferencesHelper.PutSelectedLanguage(this, 2);
                    Locale.Default = ruLocale;
                    var config1 = new Configuration { Locale = ruLocale };
                    BaseContext.Resources.UpdateConfiguration(config1, BaseContext.Resources.DisplayMetrics);
                    break;
                case 2:
                    var spanishLocale = new Locale("es");
                    if (currentLocale == spanishLocale)
                        return;
                    _languageChanged = true;
                    _preferencesHelper.PutSelectedLanguage(this, 3);
                    Locale.Default = spanishLocale;
                    var config2 = new Configuration { Locale = spanishLocale };
                    BaseContext.Resources.UpdateConfiguration(config2, BaseContext.Resources.DisplayMetrics);
                    break;
                default:
                    break;
            }
        }

        private void OnSupportUsClicked(object sender, EventArgs e)
        {
            if (_inactive)
                return;
            _inactive = true;

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle(Resources.GetString(Resource.String.SupportUsTitle))
                    .SetMessage(Resources.GetString(Resource.String.SupportUsText))
                    .SetNegativeButton(Resources.GetString(Resource.String.AboutDonatesButton), OnDonateUsClicked)
                    .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), AlertConfirmButtonClicked)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void OnDonateUsClicked(object sender, EventArgs e)
        {
            _inactive = false;
            ((Android.Support.V7.App.AlertDialog)sender).Dismiss();

            if (_inactive)
                return;
            _inactive = true;

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle(Resources.GetString(Resource.String.DonateTitle))
                    .SetMessage(Resources.GetString(Resource.String.DonateText))
                    .SetNegativeButton(Resources.GetString(Resource.String.GoToSiteButton), YandexMoneyCopied)
                    .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), AlertConfirmButtonClicked)
                    .SetCancelable(false)
                    .Create();

            Analytics.TrackEvent("User open donate alert");

            dialog.Show();
        }

        private void YandexMoneyCopied(object sender, DialogClickEventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://money.yandex.ru/to/410015425804928");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);

            _inactive = false;
        }

        private void OnThanksButtonClicked(object sender, EventArgs e)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            var prev = SupportFragmentManager.FindFragmentByTag(nameof(ThanksFragment));
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);

            var dialog = ThanksFragment.NewInstance();
            dialog.Cancelable = false;
            dialog.Show(ft, nameof(ThanksFragment));
        }

        private void AlertConfirmButtonClicked(object sender, DialogClickEventArgs e)
        {
            _inactive = false;
            ((Android.Support.V7.App.AlertDialog)sender).Dismiss();
        }

        private void OnContactUsLongClicked(object sender, View.LongClickEventArgs e)
        {
            Android.Content.ClipboardManager clipboard = (Android.Content.ClipboardManager)GetSystemService(ClipboardService);
            ClipData clip = ClipData.NewPlainText("label", "biblegamedev@gmail.com");
            clipboard.PrimaryClip = clip;

            Toast.MakeText(this, Resources.GetString(Resource.String.EmailCopiedLabel), ToastLength.Short).Show();
        }

        private void OnContactUsClicked(object sender, EventArgs e)
        {
            var emailIntent = new Intent(Intent.ActionSend);
            // The intent does not have a URI, so declare the "text/plain" MIME type
            emailIntent.SetType("vnd.android.cursor.dir/email");
            emailIntent.PutExtra(Intent.ExtraEmail, new[] { "biblegamedev@gmail.com" }); // recipients
            emailIntent.PutExtra(Intent.ExtraSubject, "Message from FPOW game");
            emailIntent.PutExtra(Intent.ExtraText, string.Empty);

            try
            {
                StartActivityForResult(emailIntent, _emailRequestCode);
            }
            catch (Exception ex)
            {
                Android.Content.ClipboardManager clipboard = (Android.Content.ClipboardManager)GetSystemService(ClipboardService);
                ClipData clip = ClipData.NewPlainText("label", "biblegamedev@gmail.com");
                clipboard.PrimaryClip = clip;

                Toast.MakeText(this, Resources.GetString(Resource.String.EmailCopiedLabel), ToastLength.Short).Show();
            }
        }

        public override void OnBackPressed()
        {
            Intent myIntent = new Intent(this, typeof(MainActivity));
            myIntent.PutExtra("languageChanged", _languageChanged);
            SetResult(Result.Ok, myIntent);
            Finish();
        }

        public static Intent CreateStartIntent(Context context, string message = null)
        {
            var intent = new Intent(context, typeof(ContactsActivity));

            return intent;
        }
    }
}