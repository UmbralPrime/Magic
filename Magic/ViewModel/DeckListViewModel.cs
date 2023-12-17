using Magic.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.ViewModel
{
    public class DeckListViewModel:BaseViewModel
    {
        public DeckListViewModel()
        {
            Decks = new ObservableCollection<Deck>();
            DeckCards = new ObservableCollection<DeckCards>();
            SelectedDeck = new Deck();
        }
        public ObservableCollection<Deck> Decks { get; set; }
        public ObservableCollection<DeckCards> DeckCards { get; set; }
        public Deck SelectedDeck { get; set; }
    }
}
