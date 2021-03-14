using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDdeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        
        public Page2()
        {
            InitializeComponent();
            animate();
           
        }

        public async Task animate()
        {
            ımage.Opacity = 0;
            await ımage.FadeTo(1, 4000);
            Application.Current.MainPage = new MainPage();
        }
    }
}