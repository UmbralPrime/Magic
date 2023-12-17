using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Classes
{
    public class Deck:Magic
    {
        
        public Deck()
        {
            DeckCards = new ObservableCollection<DeckCards>();
            Cards = new ObservableCollection<Card>();
        }
        public ObservableCollection<DeckCards> DeckCards { get; set; }
        [NotMapped]
        public ObservableCollection<Card> Cards { get; set; }
        override public string ToString()
        {
            return Name;
        }
    }
}
