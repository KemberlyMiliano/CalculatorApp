using System;
using CalculatorApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorApp
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }

    public enum Theme
    {
        Light,
        Dark
    }
}


