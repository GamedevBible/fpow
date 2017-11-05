using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/AppTheme.Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.main);
        }
    }
}

