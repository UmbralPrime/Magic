using Magic.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Magic.ViewModel
{
    public class CardViewModel : BaseViewModel
    {
        public ObservableCollection<Card> Cards { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public List<int> PageSizes { get; set; }
        public CardViewModel()
        {
            Cards = new ObservableCollection<Card>();
            Page = 1;
            PageSize = 20;
            Search = "";
            PageSizes = new List<int> { 10, 20, 50, 100 };
        }
    }
}
