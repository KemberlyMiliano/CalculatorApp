using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CalculatorApp.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnToggled(System.Object sender, EventArgs e)
        {
            Theme themeRequested = App.AppTheme == Theme.Light ? Theme.Dark : Theme.Light;
            MessagingCenter.Send<Page, Theme>(this, "ModeChanged", themeRequested);
            SetIcon();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetIcon();
        }

        void SetIcon()
        {
            if (App.AppTheme == Theme.Light)
            {
                //DeleteButton.ImageSource = "delete";
            }
            else
            {
                //DeleteButton.ImageSource = "deleteGray";
            }
        }

    }
}
