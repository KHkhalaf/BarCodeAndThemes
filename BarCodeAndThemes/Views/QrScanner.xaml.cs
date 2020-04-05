using BarCodeAndThemes.Themes;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarCodeAndThemes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrScanner : ContentPage
    {
        public QrScanner()
        {
            InitializeComponent();
            
        }
        private async void ScanQR_Clicked(object sender, EventArgs e)
        {
            scanner.IsVisible = true;
            scanner.IsScanning = true;
            scanner.IsAnalyzing = true;
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() => { 
                txtBarcode.Text = result.Text;
                scanner.IsAnalyzing = false;
                scanner.IsScanning = false;
                scanner.IsVisible = false;
            });
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            bool isLightTheme = e.Value;
            if (isLightTheme)
            { 
                lbltheme.Text = "enable light theme";
            }
            else
            {
                lbltheme.Text = "enable dark theme";
            }
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (isLightTheme)
                {
                    case true:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case false:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
    }
}