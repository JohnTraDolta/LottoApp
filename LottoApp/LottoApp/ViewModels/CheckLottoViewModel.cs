﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Windows.Input;
using LottoApp.Models;
using Xamarin.Forms;

namespace LottoApp
{
    public class CheckLottoViewModel : INotifyPropertyChanged
    {
        private List<LottoCoupon> _coupons;
        public ObservableCollection<LottoCoupon> Coupons { get; set; }

        private List<int> PickedNumbers = new List<int>();
        private bool _canPress;

        public bool CanPress
        {
            get { return _canPress; }
            set
            {
                _canPress = !value;
                OnPropertyChanged(nameof(CanPress));
            }
        }

        private string pickedNumbersString;

        public string PickedNumbersString
        {
            get => pickedNumbersString;
            set
            {
                pickedNumbersString = value;
                OnPropertyChanged(nameof(PickedNumbersString));
            }
        }

        public ICommand show => new Command(() =>
                {
                    foreach (var number in PickedNumbers)
                    {
                        Debug.WriteLine(number);
                    }
                });
        public ObservableCollection<int> Numbers { get; set; } = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };

        public CheckLottoViewModel()
        {
            Coupons = new ObservableCollection<LottoCoupon>()
                {
                    new LottoCoupon("Mors Lotto", new List<Line>
                    {
                        new Line(new List<int>{5,6,11,13,18,20,28}),
                        new Line(new List<int>{2,4,10,11,20,22,30}),
                        new Line(new List<int>{1,5,8,10,20,32,33}),
                        new Line(new List<int>{5,10,11,12,18,20,28}),
                        new Line(new List<int>{3,4,5,7,9,10,16}),
                        new Line(new List<int>{10,11,16,17,20,22,23}),
                        new Line(new List<int>{8,11,13,20,21,22,30}),
                        new Line(new List<int>{4,5,7,13,15,20,24}),
                        new Line(new List<int>{3,5,6,7,8,10,32}),
                        new Line(new List<int>{5,12,14,19,22,27,32}),
                    }),

                    new LottoCoupon("Fælles Lotto",
                        new List<Line>
                        {
                            new Line(new List<int>{1,7,10,16,20,24,27}),
                            new Line(new List<int>{3,6,8,11,14,21,34}),
                            new Line(new List<int>{2,4,11,12,20,22,28}),
                            new Line(new List<int>{8,11,13,19,20,21,32}),
                            new Line(new List<int>{7,9,10,17,22,28,32}),
                            new Line(new List<int>{4,9,10,24,29,33,34}),
                            new Line(new List<int>{4,5,7,10,16,22,25,30}),
                            new Line(new List<int>{6,7,12,16,25,26,30}),
                            new Line(new List<int>{3,4,5,12,13,15,20}),
                            new Line(new List<int>{1,11,13,19,23,29,30}),
                        })};
        }



        public ICommand PickedNumbersChangedCommand => new Command((x) =>
        {
            IList<object> objectsToExtractNumbersFrom = (IList<object>)x;
            List<int> listOfNumbers = new List<int>();
            foreach (var item in objectsToExtractNumbersFrom)
            {

                if (int.TryParse(item.ToString(), out int number))
                {
                    listOfNumbers.Add(number);
                    if (PickedNumbers.Contains(number))
                    {
                        continue;
                    }
                    else
                    {
                        PickedNumbers.Add(number);
                    }
                }
            }
            List<int> list = PickedNumbers.Except(listOfNumbers).ToList();
            PickedNumbers = PickedNumbers.Except(list).ToList();
            PickedNumbers.Sort();

            PickedNumbersString = string.Join(" ", PickedNumbers.Select(e => e.ToString()));
        });
        #region property changed event and event handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
}
