using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using LottoApp.Annotations;
using Xamarin.Forms;

namespace LottoApp.Models
{
    public class LottoCoupon : ICoupon, INotifyPropertyChanged
    {
        private string _pickedNumbersString = " ";

        public LottoCoupon(string name, List<Line> lines)
        {
            Name = name;
            NumbersToPickFrom = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
            PickedNumbers = new Line(new List<int>());
            Lines = lines;
        }

        public string Name { get; }
        public List<Line> Lines { get; }
        public List<int> NumbersToPickFrom { get; }

        public string PickedNumbersString
        {
            get => _pickedNumbersString;
            set
            {
                if (value == null || value == _pickedNumbersString)
                {
                    return;
                }
                _pickedNumbersString = value;
                OnPropertyChanged(nameof(PickedNumbersString));
            }
        }

        public Line PickedNumbers { get; set; }
        public ICommand ItemSelectedCommand => new Command((pickedList) =>
        {
            IList<object> objectsToExtractNumbersFrom = (IList<object>)pickedList;
            List<int> listOfNumbers = new List<int>();
            foreach (var item in objectsToExtractNumbersFrom)
            {

                if (int.TryParse(item.ToString(), out int number))
                {
                    listOfNumbers.Add(number);
                    if (PickedNumbers.Numbers.Contains(number))
                    {
                        continue;
                    }

                    PickedNumbers.Numbers.Add(number);
                }
            }
            List<int> list = PickedNumbers.Numbers.Except(listOfNumbers).ToList();
            PickedNumbers.Numbers = PickedNumbers.Numbers.Except(list).ToList();
            PickedNumbers.Numbers.Sort();

            PickedNumbersString = string.Join(" ", PickedNumbers.Numbers.Select(e => e.ToString()));
            if (string.IsNullOrEmpty(PickedNumbersString))
            {
                PickedNumbersString = " ";
            }

        });

        public async Task CheckCoupon()
        {
            var corrects = Lines.Select(line => line.CompareTo(PickedNumbers)).ToList();
            var message = "";
            var i = 1;
            var anyCorrects = false;
            foreach (var correct in corrects)
            {
                if (correct > 1)
                {
                    message += $"Række {i} har {correct} rigtige\n";
                    anyCorrects = true;
                }
                else if (correct == 1)
                {
                    message += $"Række {i} har 1 rigtigt\n";
                    anyCorrects = true;
                }

                
            }

            if (!anyCorrects)
            {
                message = "Der var ingen rigtige";
            }
            await Application.Current.MainPage.DisplayAlert(Name, message, "Ok");

        }

        public ICommand CheckCouponCommand => new Command(async () => await CheckCoupon());

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}