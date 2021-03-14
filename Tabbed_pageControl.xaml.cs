using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using Rg.Plugins.Popup.Extensions;

using System.ComponentModel;
namespace IDdeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    public partial class Tabbed_pageControl : TabbedPage
    {
      
        ISimpleAudioPlayer player;
        ZXingBarcodeImageView barcode;
        public Tabbed_pageControl()
        {
            InitializeComponent();
            var realmDb = Realm.GetInstance();
            var myItemSource = realmDb.All<data>().ToList();
            listem.ItemsSource = myItemSource;
           

        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await DisplayAlert("Hata",
                    "Biyometrik kimlik doğrulama mevcut değil veya yapılandırılmamış.", "TAMAM");
                return;
            }

            AuthenticationRequestConfiguration conf =
                new AuthenticationRequestConfiguration("Doğrulama",
                "Kişisel verilerinize erişimi doğrulayın");

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            if (authResult.Authenticated)
            {
                
                await DisplayAlert("Başarılı", "Doğrulama Başarılı", "TAMAM");
            }
            else
            {
                await DisplayAlert("Başarısız", "Doğrulama Başarısız", "TAMAM");
            }
        }
       
        private async void qr_Clicked(object sender, EventArgs e)
        {
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 500;
            barcode.BarcodeOptions.Height = 500;


            barcode.BarcodeValue = giris.Text;
            var realmDb = Realm.GetInstance();
            var datam = realmDb.All<data>().ToList();
            var maxID = 0;
            if (datam.Count != 0)
            {
                maxID = datam.Max(m => m.ID) + 1;
            }
            var veri = new data
            {
                ID = maxID,
                MYvalue = "Barkod Değeri: "+giris.Text
            };
            realmDb.Write(() =>
            {
                realmDb.Add(veri);
            });
            var dataList = realmDb.All<data>().ToList();
            listem.ItemsSource = dataList;
            await DisplayAlert("Uyarı", "İdda kaydedildi", "Tamam");

            giris.Text = "";

            codeqr.Children.Add(barcode);
        }

        private async void listem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var selectKisi = (data)e.SelectedItem;
            var lv = (ListView)sender;

            await Navigation.PushPopupAsync(new popUpWork(selectKisi.ID.ToString()));
            lv.SelectedItem = null;

        }

        private void listem_Refreshing(object sender, EventArgs e)
        {
            var realmDb = Realm.GetInstance();
            var myItemSource = realmDb.All<data>().ToList();
            listem.ItemsSource = myItemSource;
            listem.IsRefreshing = false;
        }
       

    }
}