using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Content.Res;
using Android.Content;
using CalculatorApp.Styles;
using Android.Support.V7.App;

namespace CalculatorApp.Droid
{
    [Activity(Label = "CalculatorApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
            SetAppTheme();
            MessagingCenter.Subscribe<Page, Theme>(this, "ModeChanged", callback: OnModeChanged);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void SetAppTheme()
        {
            if (Resources.Configuration.UiMode.HasFlag(UiMode.NightYes))
                SetTheme(CalculatorApp.Theme.Dark);
            else
                SetTheme(CalculatorApp.Theme.Light);
        }

        void SetTheme(Theme mode)
        {
            if (mode == CalculatorApp.Theme.Dark)
            {
                if (App.AppTheme == CalculatorApp.Theme.Dark)
                    return;
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                if (App.AppTheme != CalculatorApp.Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
            }
            App.AppTheme = mode;
        }

        private void OnModeChanged(Page arg1, Theme theme)
        {
            if (theme == CalculatorApp.Theme.Light)
            {
                Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightNo);
            }
            else
            {
                Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightYes);
            }
            SetTheme(theme);
        }


    }
}