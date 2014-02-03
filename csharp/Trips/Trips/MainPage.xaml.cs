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
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Trips
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public Button[] buttons;
        public Gameplay gameplay;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.buttons = new Button[] { slot0, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8 };
            ResetGame();
        }

        void ResetGame()
        {
            gameplay = new Gameplay();
            this.DataContext = gameplay;
            foreach(Button button in this.buttons){
                button.Content = "";
                button.Background = null;
            }
        }

        private bool gameButton_Click(int slot, object sender)
        {
            if(gameplay.hasFinished())
            {
                return false;
            }
            
            gameplay.selectSlot(slot);
            ((Button)sender).Content = gameplay.selections[slot];

            if(gameplay.hasFinished())
            {
                foreach (int winningElement in gameplay.getWinningRow())
                {
                    this.buttons[winningElement].Background = new SolidColorBrush(Color.FromArgb(255, 0, 100, 255));
                }
            }
            return true;
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
            ResetGame();
        }
    }
}
