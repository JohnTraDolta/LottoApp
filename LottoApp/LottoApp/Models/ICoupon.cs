using System.Collections.Generic;
using System.Threading.Tasks;

namespace LottoApp.Models
{
    public interface ICoupon
    {
        string Name { get; }
        List<Line> Lines { get; }
        List<int>  NumbersToPickFrom { get; }
        Line PickedNumbers { get; set; }
        Task CheckCoupon();


    }
}