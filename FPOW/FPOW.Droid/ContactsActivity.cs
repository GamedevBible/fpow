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

namespace FPOW.Droid
{
    [Activity(Label = "ContactsActivity", Theme = "@style/AppTheme.Main", Icon = "@drawable/icon")]
    public class ContactsActivity : AppCompatActivity
    {
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.contacts);

            _version = FindViewById<TextView>(Resource.Id.appVersion);
            _lessons = FindViewById<TextView>(Resource.Id.lessons);
            _contactUs = FindViewById<TextView>(Resource.Id.contactUs);
            _supportUs = FindViewById<TextView>(Resource.Id.supportUs);
            _thanksButton = FindViewById<ImageButton>(Resource.Id.thanksButton);

            _lessonsLayout = FindViewById<View>(Resource.Id.lessonsLayout);
            _contactUsLayout = FindViewById<View>(Resource.Id.contactUsLayout);
            _supportUsLayout = FindViewById<View>(Resource.Id.supportUsLayout);

            _version.Text = $"������ ���������� {PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName}";
            
            _thanksButton.Click += OnThanksButtonClicked;

            //if Landscape
            if (WindowManager.DefaultDisplay.Rotation == SurfaceOrientation.Rotation90 || WindowManager.DefaultDisplay.Rotation == SurfaceOrientation.Rotation270)
            {
                string text = "<font>� ��� ���� ������� ��� �����������? </font>" +
                "<font>�������� ���: </font><font color=#01A7F2>biblegamedev@gmail.com</font>";

                _contactUs.SetText(Html.FromHtml(text), TextView.BufferType.Spannable);
            }
            else
            {
                string text = "<font>� ��� ���� ������� ��� �����������?</font><br>" +
                "<font>�������� ���: </font><font color=#00c853>biblegamedev@gmail.com</font>";

                _contactUs.SetText(Html.FromHtml(text), TextView.BufferType.Spannable);
            }

            _lessons.Text = 
                $"�������� ������";

            //string supportText = "</font><font color=#01A7F2>- ���������� ��� -</font>";

            //_supportUs.SetText(Html.FromHtml(supportText), TextView.BufferType.Spannable);

            _supportUs.Text = "���������� ���";

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

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle($"�������� ������")
                    .SetMessage("� ��� ���� ������� �� ������? �� ������ ������ ������ �� ��� �� Email! "+
                    "����� �� ������ ������� ������ �������������� ��� ������ ������ �� ��������! ������� ���� � ������� ������� �� ������ http://apologetica.ru.")
                    .SetNegativeButton("������� �� ����", GoToLessonsSite)
                    .SetPositiveButton("�������", AlertConfirmButtonClicked)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void GoToLessonsSite(object sender, DialogClickEventArgs e)
        {
            _inactive = false;

            Analytics.TrackEvent("User go to Bible lessons site");

            var uri = Android.Net.Uri.Parse("http://apologetica.ru/uroki/uroki-po-izucheniyu-biblii.html");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void OnSupportUsClicked(object sender, EventArgs e)
        {
            if (_inactive)
                return;
            _inactive = true;

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle("���������� ���")
                    .SetMessage("������� ������! �� ������ ������ ���������� ���: �������� ������ ���������� 5 ����� � �������� Play Market, "+
                    "������ �� ����������� � ����� �������� � �������� ������, ����������� ������� � �������� �� ���� ����������, "+
                    "������� ��� ������������� ���������������. ������� ��� �� ���� ���������!")
                    .SetNegativeButton("� ��������������", OnDonateUsClicked)
                    .SetPositiveButton("�������", AlertConfirmButtonClicked)
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
                    .SetTitle("��������� BibleGameDev")
                    .SetMessage("��� ����������� ��������� �������� BibleGameDev �������� ������������ � �������������."+
                    " ���������� ��� ������ ��������������� ����� ��������� �� ���� ������.������: 410015425804928."+
                    " �� �������, � ��������� � ������������� �� ������ ������� ���� ��� ��� ��������."+
                    " ���������� ��� �� ��������� ������! � ����� ������� ���� ����� ������� ����� ����� �������������!"+
                    " �� ��������� ��������� � ����� ������� � �������� ������!")
                    .SetNegativeButton("������� �� ����", YandexMoneyCopied)
                    .SetPositiveButton("�������", AlertConfirmButtonClicked)
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
            /*Android.Content.ClipboardManager clipboard = (Android.Content.ClipboardManager)GetSystemService(ClipboardService);
            ClipData clip = ClipData.NewPlainText("label", "410015425804928");
            clipboard.PrimaryClip = clip;

            Toast.MakeText(this, "����� ����� ����������", ToastLength.Short).Show();*/
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

            Toast.MakeText(this, "Email ����������", ToastLength.Short).Show();
        }

        private void OnContactUsClicked(object sender, EventArgs e)
        {
            var emailIntent = new Intent(Intent.ActionSend);
            // The intent does not have a URI, so declare the "text/plain" MIME type
            emailIntent.SetType("vnd.android.cursor.dir/email");
            emailIntent.PutExtra(Intent.ExtraEmail, new[] { "biblegamedev@gmail.com" }); // recipients
            emailIntent.PutExtra(Intent.ExtraSubject, "Message from BM game");
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

                Toast.MakeText(this, "Email ����������", ToastLength.Short).Show();
            }
            
        }

        public static Intent CreateStartIntent(Context context, string message = null)
        {
            var intent = new Intent(context, typeof(ContactsActivity));

            return intent;
        }
    }
}