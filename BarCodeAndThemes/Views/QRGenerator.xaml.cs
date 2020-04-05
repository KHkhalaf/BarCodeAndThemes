using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarCodeAndThemes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRGenerator : ContentPage
    {
        public QRGenerator()
        {
            InitializeComponent();
        }

        private void GenerateQR_Clicked(object sender, EventArgs e)
        {
            BarcodeImage.BarcodeValue = txtBarcode.Text;
        }
    }
}