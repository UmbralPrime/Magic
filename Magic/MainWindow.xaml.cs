﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTab = (tabControl.SelectedItem as TabItem).Name;
            switch (selectedTab)
            {
                case "tabCards":
                    CardOverview cardOverview = new CardOverview();
                    ContentWindow.Content = cardOverview;
                    break;
                case "tabDecks":
                    DeckBuilder deckBuilder = new DeckBuilder();
                    ContentWindow.Content = deckBuilder;
                    break;
                case "tabCollection":
                    DeckOverview deckOverview = new DeckOverview();
                    ContentWindow.Content = deckOverview;
                    break;
                default:
                    break;
            }
        }
    }
}
