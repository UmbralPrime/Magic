using Magic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.ViewModel
{
    public class DeckViewModel : CardViewModel
    {
        public string DeckName { get; set; }
        public Deck Deck { get; set; }
        public Card SelectedCard { get; set; }
        public Card SelectedCardToAdd { get; set; }
        public string SelectedCardId { get; set; }
        public DeckViewModel()
        {
            DeckName = "My new deck";
            Deck = new Deck();
            SelectedCard = new Card();
            SelectedCardToAdd = new Card();
            SelectedCardId = "";
        }
    }
}
