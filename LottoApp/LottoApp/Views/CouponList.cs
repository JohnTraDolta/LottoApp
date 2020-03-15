using System;

using Xamarin.Forms;

namespace LottoApp.Views
{
    public class CouponList : ContentPage
    {
        public CouponList()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

