using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDdeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
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