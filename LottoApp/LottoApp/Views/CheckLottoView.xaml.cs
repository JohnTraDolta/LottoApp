using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace LottoApp
{
    [DesignTimeVisible(false)]
    public partial class CheckLottoView : ContentPage
    {
        public double ScreenWidth { get; set; } 
        public CheckLottoView()
        {
            InitializeComponent();
            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width;
        }
    }

}
