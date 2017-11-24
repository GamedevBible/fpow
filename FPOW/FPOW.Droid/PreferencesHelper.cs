using Android.Content;
using Android.Preferences;

namespace FPOW.Droid
{
    class PreferencesHelper
    {
        private ISharedPreferences _prefs;
        private ISharedPreferencesEditor _editor;
        private int _currentLevel;
        private int _selectedLanguage;
        private string _lastVersion;

        public PreferencesHelper()
        {
            
        }

        public void InitHepler(Context context)
        {
            if (_prefs == null)
                _prefs = PreferenceManager.GetDefaultSharedPreferences(context);

            if (_editor == null)
                _editor = _prefs.Edit();
            
            _lastVersion = _prefs.GetString("lastVersion", string.Empty);
            _selectedLanguage = _prefs.GetInt("selectedLanguage", 0);
            _currentLevel = _prefs.GetInt("currentLevel", 0);
        }

        public string GetLastVersion()
        {
            return _lastVersion;
        }

        public void PutLastVersion(Context context, string version)
        {
            if (_prefs == null)
                _prefs = PreferenceManager.GetDefaultSharedPreferences(context);

            if (_editor == null)
                _editor = _prefs.Edit();

            _editor.PutString("lastVersion", version);
            _editor.Commit();
        }

        public int GetSelectedLanguage()
        {
            return _selectedLanguage;
        }

        public void PutSelectedLanguage(Context context, int language)
        {
            if (_prefs == null)
                _prefs = PreferenceManager.GetDefaultSharedPreferences(context);

            if (_editor == null)
                _editor = _prefs.Edit();

            _editor.PutInt("selectedLanguage", language);
            _editor.Commit();
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public void PutCurrentLevel(Context context, int level)
        {
            if (_prefs == null)
                _prefs = PreferenceManager.GetDefaultSharedPreferences(context);

            if (_editor == null)
                _editor = _prefs.Edit();

            _editor.PutInt("currentLevel", level);
            _editor.Commit();
        }
    }
}