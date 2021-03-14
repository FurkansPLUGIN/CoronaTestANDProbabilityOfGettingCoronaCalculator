using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDdeneme
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "MediaElement_Experimental" });

            MainPage = new Tabbed_pageControl();
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
