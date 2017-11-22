using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/AppTheme.Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private View _word1layout;
        private View _word2layout;
        private View _word3layout;
        private View _word4layout;
        private View _word5layout;
        private View _word6layout;
        private View _word7layout;
        private View _word8layout;
        private View _word9layout;

        private Button _word1button;
        private Button _word2button;
        private Button _word3button;
        private Button _word4button;
        private Button _word5button;
        private Button _word6button;
        private Button _word7button;
        private Button _word8button;
        private Button _word9button;

        private View _wordRemoveLayout;
        private Button _wordRemoveButton;

        private View _variant1Layout;
        private View _variant2Layout;
        private View _variant3Layout;
        private View _variant4Layout;
        private View _variant5Layout;
        private View _variant6Layout;
        private View _variant7Layout;
        private View _variant8Layout;
        private View _variant9Layout;
        private View _variant10Layout;
        private View _variant11Layout;
        private View _variant12Layout;
        private View _variant13Layout;
        private View _variant14Layout;
        private View _variant15Layout;
        private View _variant16Layout;

        private Button _variant1Button;
        private Button _variant2Button;
        private Button _variant3Button;
        private Button _variant4Button;
        private Button _variant5Button;
        private Button _variant6Button;
        private Button _variant7Button;
        private Button _variant8Button;
        private Button _variant9Button;
        private Button _variant10Button;
        private Button _variant11Button;
        private Button _variant12Button;
        private Button _variant13Button;
        private Button _variant14Button;
        private Button _variant15Button;
        private Button _variant16Button;

        private AppCompatImageButton _hintButton;
        private AppCompatImageButton _settingsButton;
        private TextView _level;

        private ImageView _image1View;
        private ImageView _image2View;
        private ImageView _image3View;
        private ImageView _image4View;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.main);

            InitViews();
        }

        private void InitViews()
        {
            _image1View = FindViewById<ImageView>(Resource.Id.image1View);
            _image2View = FindViewById<ImageView>(Resource.Id.image2View);
            _image3View = FindViewById<ImageView>(Resource.Id.image3View);
            _image4View = FindViewById<ImageView>(Resource.Id.image4View);

            _hintButton = FindViewById<AppCompatImageButton>(Resource.Id.hintButton);
            _settingsButton = FindViewById<AppCompatImageButton>(Resource.Id.settingsButton);
            _level = FindViewById<TextView>(Resource.Id.level);

            _variant1Button = FindViewById<Button>(Resource.Id.variant1Button);
            _variant2Button = FindViewById<Button>(Resource.Id.variant2Button);
            _variant3Button = FindViewById<Button>(Resource.Id.variant3Button);
            _variant4Button = FindViewById<Button>(Resource.Id.variant4Button);
            _variant5Button = FindViewById<Button>(Resource.Id.variant5Button);
            _variant6Button = FindViewById<Button>(Resource.Id.variant6Button);
            _variant7Button = FindViewById<Button>(Resource.Id.variant7Button);
            _variant8Button = FindViewById<Button>(Resource.Id.variant8Button);
            _variant9Button = FindViewById<Button>(Resource.Id.variant9Button);
            _variant10Button = FindViewById<Button>(Resource.Id.variant10Button);
            _variant11Button = FindViewById<Button>(Resource.Id.variant11Button);
            _variant12Button = FindViewById<Button>(Resource.Id.variant12Button);
            _variant13Button = FindViewById<Button>(Resource.Id.variant13Button);
            _variant14Button = FindViewById<Button>(Resource.Id.variant14Button);
            _variant15Button = FindViewById<Button>(Resource.Id.variant15Button);
            _variant16Button = FindViewById<Button>(Resource.Id.variant16Button);

            _variant1Layout = FindViewById<View>(Resource.Id.variant1Layout);
            _variant2Layout = FindViewById<View>(Resource.Id.variant2Layout);
            _variant3Layout = FindViewById<View>(Resource.Id.variant3Layout);
            _variant4Layout = FindViewById<View>(Resource.Id.variant4Layout);
            _variant5Layout = FindViewById<View>(Resource.Id.variant5Layout);
            _variant6Layout = FindViewById<View>(Resource.Id.variant6Layout);
            _variant7Layout = FindViewById<View>(Resource.Id.variant7Layout);
            _variant8Layout = FindViewById<View>(Resource.Id.variant8Layout);
            _variant9Layout = FindViewById<View>(Resource.Id.variant9Layout);
            _variant10Layout = FindViewById<View>(Resource.Id.variant10Layout);
            _variant11Layout = FindViewById<View>(Resource.Id.variant11Layout);
            _variant12Layout = FindViewById<View>(Resource.Id.variant12Layout);
            _variant13Layout = FindViewById<View>(Resource.Id.variant13Layout);
            _variant14Layout = FindViewById<View>(Resource.Id.variant14Layout);
            _variant15Layout = FindViewById<View>(Resource.Id.variant15Layout);
            _variant16Layout = FindViewById<View>(Resource.Id.variant16Layout);

            _wordRemoveLayout = FindViewById<View>(Resource.Id.word_remove_layout);
            _wordRemoveButton = FindViewById<Button>(Resource.Id.word_remove_button);
            _wordRemoveButton.Text = "<<";

            _word1layout = FindViewById<View>(Resource.Id.word1layout);
            _word2layout = FindViewById<View>(Resource.Id.word2layout);
            _word3layout = FindViewById<View>(Resource.Id.word3layout);
            _word4layout = FindViewById<View>(Resource.Id.word4layout);
            _word5layout = FindViewById<View>(Resource.Id.word5layout);
            _word6layout = FindViewById<View>(Resource.Id.word6layout);
            _word7layout = FindViewById<View>(Resource.Id.word7layout);
            _word8layout = FindViewById<View>(Resource.Id.word8layout);
            _word9layout = FindViewById<View>(Resource.Id.word9layout);

            _word1button = FindViewById<Button>(Resource.Id.word1button);
            _word2button = FindViewById<Button>(Resource.Id.word2button);
            _word3button = FindViewById<Button>(Resource.Id.word3button);
            _word4button = FindViewById<Button>(Resource.Id.word4button);
            _word5button = FindViewById<Button>(Resource.Id.word5button);
            _word6button = FindViewById<Button>(Resource.Id.word6button);
            _word7button = FindViewById<Button>(Resource.Id.word7button);
            _word8button = FindViewById<Button>(Resource.Id.word8button);
            _word9button = FindViewById<Button>(Resource.Id.word9button);

            // Test
            var word = "HELLO!";
            var res = GameHelper.GetLettersString(word, Locales.English);
            var a = res;
        }

        private void ApplyWordVisibility(int wordLength)
        {
            switch (wordLength)
            {
                case 1:
                    _word2layout.Visibility = 
                        _word3layout.Visibility = 
                        _word4layout.Visibility = 
                        _word5layout.Visibility = 
                        _word6layout.Visibility = 
                        _word7layout.Visibility = 
                        _word8layout.Visibility = 
                        _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 2:
                    _word2layout.Visibility = ViewStates.Visible;
                        _word3layout.Visibility =
                        _word4layout.Visibility =
                        _word5layout.Visibility =
                        _word6layout.Visibility =
                        _word7layout.Visibility =
                        _word8layout.Visibility =
                        _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 3:
                    _word2layout.Visibility = 
                    _word3layout.Visibility = ViewStates.Visible;
                    _word4layout.Visibility =
                    _word5layout.Visibility =
                    _word6layout.Visibility =
                    _word7layout.Visibility =
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 4:
                    _word2layout.Visibility =
                    _word3layout.Visibility = 
                    _word4layout.Visibility = ViewStates.Visible;
                    _word5layout.Visibility =
                    _word6layout.Visibility =
                    _word7layout.Visibility =
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 5:
                    _word2layout.Visibility =
                    _word3layout.Visibility =
                    _word4layout.Visibility =
                    _word5layout.Visibility = ViewStates.Visible;
                    _word6layout.Visibility =
                    _word7layout.Visibility =
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 6:
                    _word2layout.Visibility =
                    _word3layout.Visibility =
                    _word4layout.Visibility =
                    _word5layout.Visibility =
                    _word6layout.Visibility = ViewStates.Visible;
                    _word7layout.Visibility =
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 7:
                    _word2layout.Visibility =
                    _word3layout.Visibility =
                    _word4layout.Visibility =
                    _word5layout.Visibility =
                    _word6layout.Visibility =
                    _word7layout.Visibility = ViewStates.Visible;
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 8:
                    _word2layout.Visibility =
                    _word3layout.Visibility =
                    _word4layout.Visibility =
                    _word5layout.Visibility =
                    _word6layout.Visibility =
                    _word7layout.Visibility =
                    _word8layout.Visibility = ViewStates.Visible;
                    _word9layout.Visibility = ViewStates.Gone;
                    break;
                case 9:
                    _word2layout.Visibility =
                    _word3layout.Visibility =
                    _word4layout.Visibility =
                    _word5layout.Visibility =
                    _word6layout.Visibility =
                    _word7layout.Visibility =
                    _word8layout.Visibility =
                    _word9layout.Visibility = ViewStates.Visible;
                    break;
            }
        }
    }
}

