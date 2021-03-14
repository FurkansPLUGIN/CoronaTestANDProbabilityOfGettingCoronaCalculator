
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Android.Graphics;
using Android.Views;

namespace IDdeneme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        ZXingBarcodeImageView barcode;
        public Page1()
        {
            InitializeComponent();
           
        }
       
        private void qr_Clicked(object sender, EventArgs e)
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
            

            barcode.BarcodeValue = "https://www.youtube.com/channel/UCNQLusaGT0qnCMpK2TBQFAA";

            
            //this.Content = barcode;
            codeqr.Children.Add(barcode);
        }

        private async void senat_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}