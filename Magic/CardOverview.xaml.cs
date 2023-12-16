using Magic.Classes;
using Magic.ViewModel;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Magic
{
    /// <summary>
    /// Interaction logic for CardOverview.xaml
    /// </summary>
    public partial class CardOverview : UserControl
    {
        public CardViewModel vm = new CardViewModel();
        public IMtgServiceProvider MtgService = new MtgServiceProvider();
        public CardOverview()
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
            txtCard.Text = "";
            vm.Page = 1;
            LoadCards();
        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadCards();
        }
    }
}
