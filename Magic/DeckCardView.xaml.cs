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
using System.Windows.Shapes;

namespace Magic
{
    /// <summary>
    /// Interaction logic for DeckCardView.xaml
    /// </summary>
    public partial class DeckCardView : Window
    {
        CardListViewModel vm = new CardListViewModel();
        public DeckCardView(ObservableCollection<Card> cards)
        {
            InitializeComponent();
            vm.Cards = cards;
            DataContext = vm;
        }
    }
}
