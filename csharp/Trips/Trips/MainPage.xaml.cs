using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Trips
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public Gameplay gameplay;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            gameplay = new Gameplay();
            this.DataContext = gameplay;
        }

        private void gameButton_Click(int slot, object sender)
        {
            gameplay.selectSlot(slot);
            ((Button)sender).Content = gameplay.selections[slot];
        }


        private void slot0_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(0, sender);
        }


        private void slot1_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(1, sender);
        }


        private void slot2_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(2, sender);
        }


        private void slot3_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(3, sender);
        }

        private void slot4_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(4, sender);
        }

        private void slot5_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(5, sender);
        }

        private void slot6_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(6, sender);
        }


        private void slot7_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(7, sender);
        }


        private void slot8_Click(object sender, RoutedEventArgs e)
        {
            gameButton_Click(8, sender);
        }

        
        private void reset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
