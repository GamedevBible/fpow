using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FPOW.Droid.GameClasses;
using Java.Util;
using System.Collections.Generic;
using System.Linq;
using System;

/* Перед обновлением:
 * - Проверить сколько уровней, и если надо изменить константу
 * - Нужно ли показывать "Что нового", если да, обновить диалог и разкомментировать флаг
 * - Повысить версию
 * - Аналитика Release
 * - Добавить слова в Words во все методы и в Images добавить картинки
 
     */

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/AppTheme.Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private const int _contactsActivityCode = 14;

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

        private Locales _currentLocale;
        private int _currentLevel;
        private PreferencesHelper _preferencesHelper;
        private int[] _variantsIntArray;

        /*
         1 = english
         2 = russian
         3 = spanish*/
        private bool _needShowWhatsNew;
        private string _currentWord;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (bundle != null)
            {
                //_greetingsWasShowed = bundle.GetBoolean(nameof(_greetingsWasShowed));
            }

            _preferencesHelper = new PreferencesHelper();
            _preferencesHelper.InitHepler(this);

            _currentLevel = _preferencesHelper.GetCurrentLevel();

            //_needShowWhatsNew = true;

            if (_currentLevel == 0)
            {
                ShowGreetingsAlert();
                _currentLevel = 1;
                _preferencesHelper.PutCurrentLevel(this, _currentLevel);
                _preferencesHelper.PutLastVersion(this, PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName);
            }
            else
            if (!_preferencesHelper.GetLastVersion().Equals(PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName))
            {
                if (_needShowWhatsNew)
                    ShowWhatsNewAlert();
                _preferencesHelper.PutLastVersion(this, PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName);
            }

            ApplyCulture();
            SetContentView (Resource.Layout.main);

            InitViews();

            InstallLevelAndStart();
        }

        private void ShowWhatsNewAlert()
        {
            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle($"{Resources.GetString(Resource.String.VersionTitle)} {PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName}")
                    .SetMessage(Resources.GetString(Resource.String.WhatsNewTitle) + "\n"
                    + (_currentLocale == Locales.English ? FpowConfig.WhatsNewEnglishMessage : _currentLocale == Locales.Russian
                        ? FpowConfig.WhatsNewRussianMessage
                        : FpowConfig.WhatsNewSpanishMessage))
                    .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), CloseDialog)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void ShowGreetingsAlert()
        {
            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle(Resources.GetString(Resource.String.GreetingsTitle))
                    .SetMessage(Resources.GetString(Resource.String.GreetingsMessage))
                    .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), CloseDialog)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void CloseDialog(object sender, DialogClickEventArgs e)
        {
            ((Android.Support.V7.App.AlertDialog)sender).Dismiss();
        }

        private void InstallLevelAndStart()
        {
            if (_currentLevel > FpowConfig.COUNT_OF_LEVELS)
            {
                ShowNoMoreLevelsDialog();
                ClearWordArea();
                // TODO Need disable all buttons and images and hint
                EnableAllButtons(false);
                ApplyWordVisibility(9);
                _variantsIntArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                _variant1Button.Text = _variant2Button.Text = _variant3Button.Text =
                    _variant4Button.Text = _variant5Button.Text = _variant6Button.Text =
                    _variant1Button.Text = _variant1Button.Text = _variant1Button.Text =
                    _variant7Button.Text = _variant8Button.Text = _variant9Button.Text =
                    _variant10Button.Text = _variant11Button.Text = _variant12Button.Text =
                    _variant13Button.Text = _variant14Button.Text = _variant15Button.Text =
                    _variant16Button.Text = string.Empty;
                _level.Text = $"{FpowConfig.COUNT_OF_LEVELS} / {FpowConfig.COUNT_OF_LEVELS}";
                return;
            }

            _currentWord = _currentLocale == Locales.English 
                    ? GameWords.GetEnglishWord(_currentLevel) 
                    : _currentLocale == Locales.Russian 
                        ? GameWords.GetRussianWord(_currentLevel) 
                        : GameWords.GetSpanishWord(_currentLevel);

            _level.Text = $"{_currentLevel} / {FpowConfig.COUNT_OF_LEVELS}";

            _variantsIntArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            EnableAllButtons();
            ClearWordArea();
            InstallImages();
            ApplyWordVisibility(_currentWord.Length);
            InstallWord(_currentWord);
        }

        private void ClearWordArea()
        {
            _word1button.Text =
                _word2button.Text =
                _word3button.Text =
                _word4button.Text =
                _word5button.Text =
                _word6button.Text =
                _word7button.Text =
                _word8button.Text =
                _word9button.Text = string.Empty;
        }

        private void InstallImages()
        {
            int[] images = new int[] { };

            images = GameImages.GetGameImages(_currentLevel);

            _image1View.SetImageResource(images[0]);
            _image2View.SetImageResource(images[1]);
            _image3View.SetImageResource(images[2]);
            _image4View.SetImageResource(images[3]);
        }

        private void ShowNoMoreLevelsDialog()
        {
            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle(Resources.GetString(Resource.String.NoMoreLevelsTitle))
                    .SetMessage(Resources.GetString(Resource.String.NoMoreLevelsMessage))
                    .SetPositiveButton(Resources.GetString(Resource.String.CloseButton), CloseDialog)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void InitViews()
        {
            _image1View = FindViewById<ImageView>(Resource.Id.image1View);
            _image2View = FindViewById<ImageView>(Resource.Id.image2View);
            _image3View = FindViewById<ImageView>(Resource.Id.image3View);
            _image4View = FindViewById<ImageView>(Resource.Id.image4View);

            _hintButton = FindViewById<AppCompatImageButton>(Resource.Id.hintButton);
            _settingsButton = FindViewById<AppCompatImageButton>(Resource.Id.settingsButton);
            _settingsButton.Click += OnSettingsButtonClick;
            _hintButton.Click += OnHintButtonClicked;
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

            _variant1Layout.Click += OnVariantLayoutClicked;
            _variant2Layout.Click += OnVariantLayoutClicked;
            _variant3Layout.Click += OnVariantLayoutClicked;
            _variant4Layout.Click += OnVariantLayoutClicked;
            _variant5Layout.Click += OnVariantLayoutClicked;
            _variant6Layout.Click += OnVariantLayoutClicked;
            _variant7Layout.Click += OnVariantLayoutClicked;
            _variant8Layout.Click += OnVariantLayoutClicked;
            _variant9Layout.Click += OnVariantLayoutClicked;
            _variant10Layout.Click += OnVariantLayoutClicked;
            _variant11Layout.Click += OnVariantLayoutClicked;
            _variant12Layout.Click += OnVariantLayoutClicked;
            _variant13Layout.Click += OnVariantLayoutClicked;
            _variant14Layout.Click += OnVariantLayoutClicked;
            _variant15Layout.Click += OnVariantLayoutClicked;
            _variant16Layout.Click += OnVariantLayoutClicked;

            _wordRemoveLayout = FindViewById<View>(Resource.Id.word_remove_layout);
            _wordRemoveButton = FindViewById<Button>(Resource.Id.word_remove_button);
            _wordRemoveButton.Text = "<<";
            _wordRemoveLayout.Click += OnRemoveLayoutClicked;

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

            var currentLanguage = Locale.Default.Language;

            _currentLocale = currentLanguage == "es" ? Locales.Spain : currentLanguage == "ru" ? Locales.Russian : Locales.English;
        }

        private void OnHintButtonClicked(object sender, EventArgs e)
        {
            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.RightWordDialog)
                    .SetTitle(Resources.GetString(Resource.String.HintDialogText))
                    .SetPositiveButton(Resources.GetString(Resource.String.YesButton), OpenFirstLetter)
                    .SetNegativeButton(Resources.GetString(Resource.String.NoButton), CloseDialog)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void OpenFirstLetter(object sender, DialogClickEventArgs e)
        {
            SetButtonsDefault();

            var letter = _currentWord[0].ToString();

            if (_variant1Button.Text == letter)
            {
                ProcessFirstLetter(0, letter);
                _variant1Layout.Enabled = false;
                _variant1Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant2Button.Text == letter)
            {
                ProcessFirstLetter(1, letter);
                _variant2Layout.Enabled = false;
                _variant2Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant3Button.Text == letter)
            {
                ProcessFirstLetter(2, letter);
                _variant3Layout.Enabled = false;
                _variant3Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant4Button.Text == letter)
            {
                ProcessFirstLetter(3, letter);
                _variant4Layout.Enabled = false;
                _variant4Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant5Button.Text == letter)
            {
                ProcessFirstLetter(4, letter);
                _variant5Layout.Enabled = false;
                _variant5Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant6Button.Text == letter)
            {
                ProcessFirstLetter(5, letter);
                _variant6Layout.Enabled = false;
                _variant6Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant7Button.Text == letter)
            {
                ProcessFirstLetter(6, letter);
                _variant7Layout.Enabled = false;
                _variant7Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant8Button.Text == letter)
            {
                ProcessFirstLetter(7, letter);
                _variant8Layout.Enabled = false;
                _variant8Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant9Button.Text == letter)
            {
                ProcessFirstLetter(8, letter);
                _variant9Layout.Enabled = false;
                _variant9Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant10Button.Text == letter)
            {
                ProcessFirstLetter(9, letter);
                _variant10Layout.Enabled = false;
                _variant10Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant11Button.Text == letter)
            {
                ProcessFirstLetter(10, letter);
                _variant11Layout.Enabled = false;
                _variant11Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant12Button.Text == letter)
            {
                ProcessFirstLetter(11, letter);
                _variant12Layout.Enabled = false;
                _variant12Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant13Button.Text == letter)
            {
                ProcessFirstLetter(12, letter);
                _variant13Layout.Enabled = false;
                _variant13Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant14Button.Text == letter)
            {
                ProcessFirstLetter(13, letter);
                _variant14Layout.Enabled = false;
                _variant14Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant15Button.Text == letter)
            {
                ProcessFirstLetter(14, letter);
                _variant15Layout.Enabled = false;
                _variant15Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
            if (_variant16Button.Text == letter)
            {
                ProcessFirstLetter(15, letter);
                _variant16Layout.Enabled = false;
                _variant16Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                return;
            }
        }

        private void ProcessFirstLetter(int numberOfVariant, string letter)
        {
            _variantsIntArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            EnableAllButtons();
            ClearWordArea();

            _word1button.Text = letter.ToString();
            _variantsIntArray[numberOfVariant] = 1;
        }

        private void OnSettingsButtonClick(object sender, EventArgs e)
        {
            StartActivity(ContactsActivity.CreateStartIntent(this));
            /*_currentLevel = 1;
            _preferencesHelper.PutCurrentLevel(this, 0);

            InstallLevelAndStart();*/
        }

        private void OnRemoveLayoutClicked(object sender, EventArgs e)
        {
            SetButtonsDefault();

            var max = _variantsIntArray.Max();
            
            switch (max)
            {
                case 0:
                    return;
                case 1:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 1));
                    _word1button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 1)] = 0;
                    break;
                case 2:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 2));
                    _word2button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 2)] = 0;
                    break;
                case 3:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 3));
                    _word3button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 3)] = 0;
                    break;
                case 4:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 4));
                    _word4button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 4)] = 0;
                    break;
                case 5:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 5));
                    _word5button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 5)] = 0;
                    break;
                case 6:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 6));
                    _word6button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 6)] = 0;
                    break;
                case 7:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 7));
                    _word7button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 7)] = 0;
                    break;
                case 8:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 8));
                    _word8button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 8)] = 0;
                    break;
                case 9:
                    ReturnLetterToVariant(Array.IndexOf(_variantsIntArray, 9));
                    _word9button.Text = string.Empty;
                    _variantsIntArray[Array.IndexOf(_variantsIntArray, 9)] = 0;
                    break;
            }
        }

        private void ReturnLetterToVariant(int index)
        {
            switch (index)
            {
                case 0:
                    _variant1Layout.Enabled = true;
                    _variant1Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 1:
                    _variant2Layout.Enabled = true;
                    _variant2Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 2:
                    _variant3Layout.Enabled = true;
                    _variant3Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 3:
                    _variant4Layout.Enabled = true;
                    _variant4Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 4:
                    _variant5Layout.Enabled = true;
                    _variant5Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 5:
                    _variant6Layout.Enabled = true;
                    _variant6Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 6:
                    _variant7Layout.Enabled = true;
                    _variant7Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 7:
                    _variant8Layout.Enabled = true;
                    _variant8Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 8:
                    _variant9Layout.Enabled = true;
                    _variant9Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 9:
                    _variant10Layout.Enabled = true;
                    _variant10Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 10:
                    _variant11Layout.Enabled = true;
                    _variant11Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 11:
                    _variant12Layout.Enabled = true;
                    _variant12Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 12:
                    _variant13Layout.Enabled = true;
                    _variant13Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 13:
                    _variant14Layout.Enabled = true;
                    _variant14Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 14:
                    _variant15Layout.Enabled = true;
                    _variant15Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
                case 15:
                    _variant16Layout.Enabled = true;
                    _variant16Button.SetBackgroundResource(Resource.Drawable.button_background);
                    break;
            }
        }

        private void OnVariantLayoutClicked(object sender, EventArgs e)
        {
            var max = _variantsIntArray.Max();
            if (max == _currentWord.Length)
                return;

            switch (((View)sender).Id)
            {
                case Resource.Id.variant1Layout:
                    _variant1Layout.Enabled = false;
                    _variant1Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(0, _variant1Button.Text);
                    break;
                case Resource.Id.variant2Layout:
                    _variant2Layout.Enabled = false;
                    _variant2Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(1, _variant2Button.Text);
                    break;
                case Resource.Id.variant3Layout:
                    _variant3Layout.Enabled = false;
                    _variant3Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(2, _variant3Button.Text);
                    break;
                case Resource.Id.variant4Layout:
                    _variant4Layout.Enabled = false;
                    _variant4Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(3, _variant4Button.Text);
                    break;
                case Resource.Id.variant5Layout:
                    _variant5Layout.Enabled = false;
                    _variant5Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(4, _variant5Button.Text);
                    break;
                case Resource.Id.variant6Layout:
                    _variant6Layout.Enabled = false;
                    _variant6Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(5, _variant6Button.Text);
                    break;
                case Resource.Id.variant7Layout:
                    _variant7Layout.Enabled = false;
                    _variant7Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(6, _variant7Button.Text);
                    break;
                case Resource.Id.variant8Layout:
                    _variant8Layout.Enabled = false;
                    _variant8Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(7, _variant8Button.Text);
                    break;
                case Resource.Id.variant9Layout:
                    _variant9Layout.Enabled = false;
                    _variant9Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(8, _variant9Button.Text);
                    break;
                case Resource.Id.variant10Layout:
                    _variant10Layout.Enabled = false;
                    _variant10Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(9, _variant10Button.Text);
                    break;
                case Resource.Id.variant11Layout:
                    _variant11Layout.Enabled = false;
                    _variant11Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(10, _variant11Button.Text);
                    break;
                case Resource.Id.variant12Layout:
                    _variant12Layout.Enabled = false;
                    _variant12Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(11, _variant12Button.Text);
                    break;
                case Resource.Id.variant13Layout:
                    _variant13Layout.Enabled = false;
                    _variant13Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(12, _variant13Button.Text);
                    break;
                case Resource.Id.variant14Layout:
                    _variant14Layout.Enabled = false;
                    _variant14Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(13, _variant14Button.Text);
                    break;
                case Resource.Id.variant15Layout:
                    _variant15Layout.Enabled = false;
                    _variant15Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(14, _variant15Button.Text);
                    break;
                case Resource.Id.variant16Layout:
                    _variant16Layout.Enabled = false;
                    _variant16Button.SetBackgroundResource(Resource.Drawable.button_disabled);
                    ProcessLetter(15, _variant16Button.Text);
                    break;
            }
        }

        private void ProcessLetter(int number, string letter)
        {
            var max = _variantsIntArray.Max();

            if (max == _currentWord.Length)
                return;

            switch (max)
            {
                case 9:
                    return;
                case 0:
                    _variantsIntArray[number] = 1;
                    _word1button.Text = letter;
                    break;
                case 1:
                    _variantsIntArray[number] = 2;
                    _word2button.Text = letter;

                    if (_currentWord.Length == 2)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 2:
                    _variantsIntArray[number] = 3;
                    _word3button.Text = letter;

                    if (_currentWord.Length == 3)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 3:
                    _variantsIntArray[number] = 4;
                    _word4button.Text = letter;

                    if (_currentWord.Length == 4)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 4:
                    _variantsIntArray[number] = 5;
                    _word5button.Text = letter;

                    if (_currentWord.Length == 5)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper() &&
                        _currentWord[4].ToString().ToUpper() == _word5button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 5:
                    _variantsIntArray[number] = 6;
                    _word6button.Text = letter;

                    if (_currentWord.Length == 6)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper() &&
                        _currentWord[4].ToString().ToUpper() == _word5button.Text.ToUpper() &&
                        _currentWord[5].ToString().ToUpper() == _word6button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 6:
                    _variantsIntArray[number] = 7;
                    _word7button.Text = letter;

                    if (_currentWord.Length == 7)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper() &&
                        _currentWord[4].ToString().ToUpper() == _word5button.Text.ToUpper() &&
                        _currentWord[5].ToString().ToUpper() == _word6button.Text.ToUpper() &&
                        _currentWord[6].ToString().ToUpper() == _word7button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 7:
                    _variantsIntArray[number] = 8;
                    _word8button.Text = letter;

                    if (_currentWord.Length == 8)
                    {
                        if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper() &&
                        _currentWord[4].ToString().ToUpper() == _word5button.Text.ToUpper() &&
                        _currentWord[5].ToString().ToUpper() == _word6button.Text.ToUpper() &&
                        _currentWord[6].ToString().ToUpper() == _word7button.Text.ToUpper() &&
                        _currentWord[7].ToString().ToUpper() == _word8button.Text.ToUpper())
                            InstallNextWord();
                        else
                            SetButtonsWrong();
                    }

                    break;
                case 8:
                    _variantsIntArray[number] = 9;
                    _word9button.Text = letter;

                    if (_currentWord[0].ToString().ToUpper() == _word1button.Text.ToUpper() &&
                        _currentWord[1].ToString().ToUpper() == _word2button.Text.ToUpper() &&
                        _currentWord[2].ToString().ToUpper() == _word3button.Text.ToUpper() &&
                        _currentWord[3].ToString().ToUpper() == _word4button.Text.ToUpper() &&
                        _currentWord[4].ToString().ToUpper() == _word5button.Text.ToUpper() &&
                        _currentWord[5].ToString().ToUpper() == _word6button.Text.ToUpper() &&
                        _currentWord[6].ToString().ToUpper() == _word7button.Text.ToUpper() &&
                        _currentWord[7].ToString().ToUpper() == _word8button.Text.ToUpper() &&
                        _currentWord[8].ToString().ToUpper() == _word9button.Text.ToUpper())
                        InstallNextWord();
                    else
                        SetButtonsWrong();

                    break;
            }
        }

        private void InstallNextWord()
        {
            var ft = SupportFragmentManager.BeginTransaction();
            var prev = SupportFragmentManager.FindFragmentByTag(nameof(RightAnswerFragment));
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);

            var dialog = RightAnswerFragment.NewInstance(_currentWord);
            dialog.OnClosed += OnRightAnswerDialogDismissed;
            dialog.Show(ft, nameof(RightAnswerFragment));

            _currentLevel++;

            _preferencesHelper.PutCurrentLevel(this, _currentLevel);
        }

        private void OnRightAnswerDialogDismissed(object sender, EventArgs e)
        {
            InstallLevelAndStart();
        }

        private void EnableAllButtons(bool enabled = true)
        {
            _variant1Layout.Enabled = _variant2Layout.Enabled = _variant3Layout.Enabled =
                _variant4Layout.Enabled = _variant5Layout.Enabled = _variant6Layout.Enabled =
                _variant7Layout.Enabled = _variant8Layout.Enabled = _variant9Layout.Enabled =
                _variant10Layout.Enabled = _variant11Layout.Enabled = _variant12Layout.Enabled =
                _variant13Layout.Enabled = _variant14Layout.Enabled = _variant15Layout.Enabled =
                _variant16Layout.Enabled = enabled;

            _variant1Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant2Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant3Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant4Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant5Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant6Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant7Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant8Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant9Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant10Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant11Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant12Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant13Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant14Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant15Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
            _variant16Button.SetBackgroundResource(enabled ? Resource.Drawable.button_background : Resource.Drawable.button_disabled);
        }

        private void SetButtonsDefault()
        {
            _word1button.SetBackgroundResource(Resource.Drawable.field_background);
            _word2button.SetBackgroundResource(Resource.Drawable.field_background);
            _word3button.SetBackgroundResource(Resource.Drawable.field_background);
            _word4button.SetBackgroundResource(Resource.Drawable.field_background);
            _word5button.SetBackgroundResource(Resource.Drawable.field_background);
            _word6button.SetBackgroundResource(Resource.Drawable.field_background);
            _word7button.SetBackgroundResource(Resource.Drawable.field_background);
            _word8button.SetBackgroundResource(Resource.Drawable.field_background);
            _word9button.SetBackgroundResource(Resource.Drawable.field_background);
        }

        private void SetButtonsWrong()
        {
            _word1button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word2button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word3button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word4button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word5button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word6button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word7button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word8button.SetBackgroundResource(Resource.Drawable.button_wrong);
            _word9button.SetBackgroundResource(Resource.Drawable.button_wrong);
        }

        private void ApplyCulture()
        {
            // Set default culture by phone culture
            var listOfRussianLocales = new List<Locale>
            {
                new Locale("ru"),
                new Locale("be"),
                new Locale("uk"),
                new Locale("az"),
                new Locale("hy"),
                new Locale("kk"),
                new Locale("ky"),
                new Locale("tt"),
                new Locale("uz")
            };

            var currentLocale = Locale.Default;

            if (listOfRussianLocales.Any(t => t.Language == currentLocale.Language))
            {
                var newLocale = new Locale("ru");

                Locale.Default = newLocale;
                var config = new Configuration { Locale = newLocale };
                BaseContext.Resources.UpdateConfiguration(config, BaseContext.Resources.DisplayMetrics);
            }

            var spanishLocale = new Locale("es");

            if (currentLocale.Language == spanishLocale.Language)
            {
                Locale.Default = spanishLocale;
                var config = new Configuration { Locale = spanishLocale };
                BaseContext.Resources.UpdateConfiguration(config, BaseContext.Resources.DisplayMetrics);
            }
        }

        private void InstallWord(string word)
        {
            var newWord = GameHelper.GetLettersString(word, _currentLocale);

            _variant1Button.Text = newWord[0].ToString();
            _variant2Button.Text = newWord[1].ToString();
            _variant3Button.Text = newWord[2].ToString();
            _variant4Button.Text = newWord[3].ToString();
            _variant5Button.Text = newWord[4].ToString();
            _variant6Button.Text = newWord[5].ToString();
            _variant7Button.Text = newWord[6].ToString();
            _variant8Button.Text = newWord[7].ToString();
            _variant9Button.Text = newWord[8].ToString();
            _variant10Button.Text = newWord[9].ToString();
            _variant11Button.Text = newWord[10].ToString();
            _variant12Button.Text = newWord[11].ToString();
            _variant13Button.Text = newWord[12].ToString();
            _variant14Button.Text = newWord[13].ToString();
            _variant15Button.Text = newWord[14].ToString();
            _variant16Button.Text = newWord[15].ToString();
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

