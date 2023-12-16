using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Classes
{
    public class Deck:Magic
    {
        
        public Deck()
        {
            Cards = new ObservableCollection<Card>();
        }
        public ObservableCollection<Card> Cards { get; set; }
    }
}
