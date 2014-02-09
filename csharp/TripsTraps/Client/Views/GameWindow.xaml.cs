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
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        ViewManagers.GameViewManager CurrentGameViewManager;
        Models.GamePlay CurrentGamePlay;
        Models.GameUser CurrentGameUser;
        Button[] Slots;

        public GameWindow()
        {
            InitializeComponent();
            this.Loaded += GameWindow_Loaded;
        }

        async void GameWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.CurrentGameViewManager = ViewManagers.GameViewManager.Current;
            this.CurrentGamePlay = CurrentGameViewManager.CurrentGamePlay;
            this.CurrentGameUser = CurrentGameViewManager.CurrentGameUser;
            this.Slots = new Button[] { slot0, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8 };

            this.DataContext = this.CurrentGameViewManager;

            await UpdateGamePlayDataAndView();

            this.Hide();
            ViewManagers.GameViewManager.Current.CreateGamePlay();
            new WaitingWindow().Show();
            this.Close();
        }

        async Task<bool> UpdateGamePlayDataAndView()
        {
            while (this.CurrentGamePlay.CanMakeNewMoves)
            {
                await this.CurrentGameViewManager.RefreshGamePlayData();
                this.UpdateGamePlayView();
                await Task.Delay(1000);
            }
            return true;
        }

        bool UpdateGamePlayView()
        {
            int[] gameTable = this.CurrentGamePlay.GameTable;
            for (int i = 0; i < gameTable.Length; i += 1)
            {
                UpdateSlotValue(i, gameTable[i]);
            }
                return true;
        }

        void UpdateSlotValue(int index, int value)
        {
            string text = "";
            if(value==0)
            {
            }
            else if(value==CurrentGameUser.Id)
            {
                text = "x";
            }
            else
            {
                text = "o";
            }
            this.Slots[index].Content = text;
        }

        private bool gameButton_Click(int slot, object sender)
        {
            return this.CurrentGamePlay.Move(this.CurrentGameUser.Id, slot);
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

    }
}
