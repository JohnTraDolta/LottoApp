using System.Collections.Generic;
using LottoApp.Models;
using LottoApp.Views;
using Xamarin.Forms;

namespace LottoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CheckLottoView();
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

        public static readonly List<Coupon> coupons = new List<Coupon> {
            new Coupon(new List<List<int>> {
                new List<int>{5,6,11,13,18,20,28},
                new List<int>{2,4,10,11,20,22,30},
                new List<int>{1,5,8,10,20,32,33},
                new List<int>{5,10,11,12,18,20,28},
                new List<int>{3,4,5,7,9,10,16},
                new List<int>{10,11,16,17,20,22,23},
                new List<int>{8,11,13,20,21,22,30},
                new List<int>{4,5,7,13,15,20,24},
                new List<int>{3,5,6,7,8,10,32},
                new List<int>{5,12,14,19,22,27,32}}, "Mors Lotto"),
            new Coupon(new List<List<int>> {
                new List<int>{1},
                new List<int>{2},
                new List<int>{3},
                new List<int>{4},
                new List<int>{5},
                new List<int>{6},
                new List<int>{7},
                new List<int>{8},
                new List<int>{9},
                new List<int>{10}}, "Fælles Lotto")};
    }
}
