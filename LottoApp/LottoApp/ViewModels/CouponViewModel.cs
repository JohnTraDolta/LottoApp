using System;
using System.Collections.Generic;
using LottoApp.Models;

namespace LottoApp.ViewModels
{
    public class CouponViewModel
    {
        public List<Coupon> Coupons { get; set; }
        public CouponViewModel()
        {
            Coupons = App.coupons;
        }
    }
}
