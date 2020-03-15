using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace LottoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CheckLottoView : ContentPage
    {
        double width = 500.0;
        public CheckLottoView()
        {

            InitializeComponent();

            var TapMorlotto = new TapGestureRecognizer();
            var TapFalleslotto = new TapGestureRecognizer();

            TapMorlotto.Tapped += async (s, e) =>
            {
                await CouponTwo.TranslateTo(width, 0, 500, Easing.CubicOut);
                await CouponOne.TranslateTo(0, 0, 150, Easing.CubicOut);

            };
            TapFalleslotto.Tapped += async (s, e) =>
            {
                await CouponOne.TranslateTo(-width, 0, 500, Easing.CubicOut);
                await CouponTwo.TranslateTo(0, 0, 150, Easing.CubicOut);
                
            };

            MorsLotto.GestureRecognizers.Add(TapMorlotto);
            fallesLotto.GestureRecognizers.Add(TapFalleslotto);
        }
        public IReadOnlyList<object> currentSelection;


    }

}
