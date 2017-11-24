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

/* Перед обновлением:
 * - Проверить сколько уровней, и если надо изменить константу
 * - Нужно ли показывать "Что нового", если да, обновить диалог и разкомментировать флаг
 * - Повысить версию
 * - Аналитика Release
 * - Добавить слова в Words во все методы
 
     */

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/AppTheme.Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private const int COUNT_OF_LEVELS = 10;

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
        private bool _hintLocked;
        private PreferencesHelper _preferencesHelper;

        /*
         1 = english
         2 = russian
         3 = spanish*/
        private int _currentCultureID;
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

            _needShowWhatsNew = true;

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
        }

        private void ShowWhatsNewAlert()
        {
            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle($"Версия {PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName}")
                    .SetMessage("Что нового:" + "\n" + "- исправлены найденные ошибки в вопросах." + "\n" + "\n" + "Мы очень рады, что вы участвуете в нашей викторине! А мы будем делать наше приложение все более интересным для вас!")
                    .SetPositiveButton("Закрыть", CloseDialog)
                    .SetCancelable(false)
                    .Create();

            dialog.Show();
        }

        private void ShowGreetingsAlert()
        {
            /*var locale = Locale.Default.DisplayLanguage;

            var title = locale == "en" || locale == "en-US" || locale == "English" ? "Welcome!" : "Добро пожаловать!";

            var message = locale == "en" || locale == "en-US" || locale == "English"
                ? "Dear friend! This time our app supports only russian language. We are sorry for that."
                : "Дорогой друг! Мы очень рады, что ты присоединился к нашему приложению! Тебя ждут более 3000 вопросов! Желаем тебе успехов!";

            var closeButton = locale == "en" || locale == "en-US" || locale == "English" ? "Close" : "Закрыть";*/

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle("")
                    .SetMessage("")
                    .SetPositiveButton("cls", CloseDialog)
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
            if (_currentLevel == COUNT_OF_LEVELS)
            {
                ShowNoMoreLevelsDialog();
                // TODO Need disable all buttons and images and hint
                return;
            }

            _currentWord = _currentLocale == Locales.English 
                    ? Words.GetEnglishWord(_currentLevel) 
                    : _currentLocale == Locales.Russian 
                        ? Words.GetRussianWord(_currentLevel) 
                        : Words.GetSpanishWord(_currentLevel);

            _level.Text = $"{_currentLevel} / {COUNT_OF_LEVELS}";

            InstallImages();
            InstallWord(_currentWord);
        }

        private void InstallImages()
        {
            // TODO
        }

        private void ShowNoMoreLevelsDialog()
        {
            // TODO Localize

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this, Resource.Style.AlertDialogTheme)
                    .SetTitle($"Версия {PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Configurations).VersionName}")
                    .SetMessage("Что нового:" + "\n" + "- исправлены найденные ошибки в вопросах." + "\n" + "\n" + "Мы очень рады, что вы участвуете в нашей викторине! А мы будем делать наше приложение все более интересным для вас!")
                    .SetPositiveButton("Закрыть", CloseDialog)
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

            var currentLanguage = Locale.Default.Language;

            _currentLocale = currentLanguage == "es" ? Locales.Spain : currentLanguage == "ru" ? Locales.Russian : Locales.English;
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

