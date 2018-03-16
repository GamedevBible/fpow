using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;
using Android.Content.PM;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/ActivitySplash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, Icon = "@mipmap/ic_launcher"/*, NoHistory = true*/)]
    public class SplashActivity : AppCompatActivity
    {
        private bool _needStartApp = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (savedInstanceState != null)
            {
                _needStartApp = savedInstanceState.GetBoolean(nameof(_needStartApp));
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            outState.PutBoolean(nameof(_needStartApp), _needStartApp);
        }

        protected override void OnResume()
        {
            base.OnResume();
            
            AppCenter.Start("e58a932f-6903-4570-b150-be7798b4a9df",
                   typeof(Analytics), typeof(Crashes)); // PLAY MARKET

            if (!_needStartApp)
            {
                return;
            }

            _needStartApp = false;

            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            await Task.Delay(500);
            StartActivity(MainActivity.CreateStartIntent(this));
        }
    }
}