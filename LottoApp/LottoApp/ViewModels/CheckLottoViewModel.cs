using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using LottoApp.Models;
using Xamarin.Forms;

namespace LottoApp
{
    public class CheckLottoViewModel : INotifyPropertyChanged
    {
        private readonly Coupon _coupon;
        private List<int> PickedNumbers = new List<int>();

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
