using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Classes
{
    public class DeckCards
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DeckId")]
        public string DeckId { get; set; }
        [ForeignKey("CardId")]
        public string CardId { get; set; }
        public Deck Deck { get; set; }
        public Card Card { get; set; }
    }
}
