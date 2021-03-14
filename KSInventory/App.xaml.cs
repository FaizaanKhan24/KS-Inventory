using System;
using KSInventory.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KSInventory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.Orange
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
