using Android.App;
using Android.Widget;
using Android.OS;

namespace FPOW.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/AppTheme.Main", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

