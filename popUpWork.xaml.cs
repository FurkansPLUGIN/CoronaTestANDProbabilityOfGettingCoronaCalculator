
using Realms;
using Rg.Plugins.Popup.Extensions;
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
    public partial class popUpWork : Rg.Plugins.Popup.Pages.PopupPage
    {
        string realKisiId;
        public popUpWork(string kisiId)
        {
            InitializeComponent();
            realKisiId = kisiId;
        }

        private async void sil_Clicked(object sender, EventArgs e)
        {
            var realmDb = Realm.GetInstance();
            var seciliKisi = realmDb.All<data>().First(s => s.ID == Convert.ToInt32(realKisiId));
            try
            {
                using (var db = realmDb.BeginWrite())
                {
                    realmDb.Remove(seciliKisi);
                    db.Commit();
                }
                await DisplayAlert("Uyarı", "Silindi", "tamam");
                await Navigation.PopPopupAsync();

            }
            catch
            {
                await DisplayAlert("Uyarı", "Silinemedi", "tamam");
            }
        }
    }
}