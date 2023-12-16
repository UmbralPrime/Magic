using Magic.Classes;
using Magic.ViewModel;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DeckBuilder.xaml
    /// </summary>
    public partial class DeckBuilder : UserControl
    {
        public DeckViewModel vm = new DeckViewModel();
        public IMtgServiceProvider MtgService = new MtgServiceProvider();
        public DeckBuilder()
        {
            InitializeComponent();
            LoadCards();
        }
        public async void LoadCards()
        {
            vm.Cards.Clear();
            ICardService CardService = MtgService.GetCardService();
            IOperationResult<List<ICard>> result = await CardService
                                            .Where(x => x.Page, vm.Page)
                                            .Where(x => x.PageSize, vm.PageSize)
                                            .Where(x => x.Name, vm.Search)
                                            .AllAsync();
            if (result.IsSuccess)
            {
                foreach (ICard card in result.Value)
                {
                    Card newCard = new Card();
                    newCard.Name = card.Name;
                    newCard.ImageUrl = card.ImageUrl;
                    newCard.Id = card.Id;
                    if (card.ImageUrl == null)
                    {
                        newCard.ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png");
                    }
                    vm.Cards.Add(newCard);
                }
            }
            DataContext = vm;
        }

        private void NextPage(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.Page++;
            LoadCards();

        }

        private void PreviousPage(object sender, System.Windows.RoutedEventArgs e)
        {
            if (vm.Page > 1)
            {
                vm.Page--;
                vm.Cards.Clear();
            }
            LoadCards();
        }

        private void ChangePageSize(object sender, SelectionChangedEventArgs e)
        {
            LoadCards();
        }

        private void btnundo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.Search = "";
            //txtCard.Text = "";
            vm.Page = 1;
            LoadCards();
        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadCards();
        }

        private void addCardToDeck(object sender, RoutedEventArgs e)
        {
            vm.Deck.Cards.Add(vm.SelectedCardToAdd);
        }

        private void createDeck(object sender, RoutedEventArgs e)
        {
            if (vm.DeckName == "")
            {
                MessageBox.Show("Please enter a name for your deck");
                return;
            }
            else if (vm.Deck.Cards.Count == 0)
            {
                MessageBox.Show("Please add at least one card to your deck");
                return;
            }
            else if (vm.Deck.Cards.Count > 60)
            {
                MessageBox.Show("Please remove some cards from your deck");
                return;
            }
            //else if(vm.Deck.Cards.Count < 60)
            //{
            //    MessageBox.Show("Please add more cards to your deck (60)");
            //    return;
            //}
            else if (vm.Deck.Cards.GroupBy(x => x.Id).Any(g => g.Count() > 4))
            {
                MessageBox.Show("You can only have 4 of each card in your deck");
                return;
            }
            else if (vm.Deck.Cards.GroupBy(x => x.Name).Any(g => g.Count() > 1))
            {
                MessageBox.Show("You can only have 1 of each legendary card in your deck");
                return;
            }
            else
            {
                using (MagicDataContext db = new MagicDataContext())
                {
                    vm.Deck.Name = vm.DeckName;
                    vm.Deck.Id = Guid.NewGuid().ToString();                    
                    db.DeckCards.AddRange(vm.Deck.Cards.Select(x => new DeckCards { DeckId = vm.Deck.Id, CardId = x.Id }));
                    vm.Deck.Cards.Clear();
                    db.Decks.Add(vm.Deck);
                    db.SaveChanges();
                }
            }

        }

        private void deleteSelectedCard(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCard != null)
            {
                vm.Deck.Cards.Remove(vm.SelectedCard);
            }
        }
    }
}
