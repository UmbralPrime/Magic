using Magic.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.ViewModel
{
    public class CardListViewModel:BaseViewModel
    {
        public ObservableCollection<Card> Cards { get; set; }
        public CardListViewModel() 
        {
            Cards = new ObservableCollection<Card>();
        }
    }
}
