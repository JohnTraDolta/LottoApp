using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace LottoApp
{
    public class CheckLottoViewModel
    {
        private ObservableCollection<int> _pickedNumbers = new ObservableCollection<int> { 1};
        public ObservableCollection<int> PickedNumbers
        {
            get => _pickedNumbers;
            set
            {
                _pickedNumbers = value;
                Debug.WriteLine("Value added " + _pickedNumbers.ToString());
            }
        }
        public ICommand show => new Command(() => { Debug.WriteLine(PickedNumbers); });
        public List<int> Numbers { get; set; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
        public CheckLottoViewModel()
        {
        }
    }
}
