using Magic.Classes;
using Magic.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magic
{
    /// <summary>
    /// Interaction logic for DeckOverview.xaml
    /// </summary>
    public partial class DeckOverview : UserControl
    {
        public DeckListViewModel vm = new DeckListViewModel();
        public DeckOverview()
        {
            InitializeComponent();
            LoadDecks();
        }
        public void LoadDecks()
        {
            vm.Decks.Clear();
            using (MagicDataContext db = new MagicDataContext())
            {
                foreach (var deck in db.Decks)
                {
                    foreach (var deckCard in db.DeckCards.Where(x => x.DeckId == deck.Id))
                    {
                        deck.Cards.Add(db.Cards.Where(x => x.Id == deckCard.CardId).FirstOrDefault());
                    }
                    vm.Decks.Add(deck);
                }
            }
            DataContext = vm;
        }

        private void deleteSelectedDeck(object sender, RoutedEventArgs e)
        {
            if(vm.SelectedDeck != null)
            {
                using (MagicDataContext db = new MagicDataContext())
                {
                    db.Decks.Remove(db.Decks.Where(x => x.Id == vm.SelectedDeck.Id).FirstOrDefault());
                    db.SaveChanges();
                }
                LoadDecks();
            }
            else
                MessageBox.Show("Please select a deck to delete");
        }

        private void openCardWindow(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedDeck != null)
            {
                ObservableCollection<Card> cards = new ObservableCollection<Card>();
                using (MagicDataContext db = new MagicDataContext())
                {
                    foreach (var deckCard in db.DeckCards.Where(x => x.DeckId == vm.SelectedDeck.Id))
                    {
                        cards.Add(db.Cards.Where(x => x.Id == deckCard.CardId).FirstOrDefault());
                    }
                }
                DeckCardView cardList = new DeckCardView(cards);
                cardList.Show();
            }
            else
                MessageBox.Show("Please select a deck to open");
        }
    }
}
