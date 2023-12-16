using Magic.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class MagicDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=magic.db");
        }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCards> DeckCards { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
