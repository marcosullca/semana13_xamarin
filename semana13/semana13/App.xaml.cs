using System;
using semana13.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana13
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calculadora();
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
