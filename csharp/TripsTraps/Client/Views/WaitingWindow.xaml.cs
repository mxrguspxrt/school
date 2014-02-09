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
    /// Interaction logic for WaitingWindow.xaml
    /// </summary>
    public partial class WaitingWindow : Window
    {
        public WaitingWindow()
        {
            InitializeComponent();
            this.Loaded += WaitingWindow_Loaded;
        }

        async void WaitingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = ViewManagers.GameViewManager.Current;
            await WaitForOtherPlayer();

            this.Hide();
            new GameWindow().Show();
            this.Close();
        }

        async Task<bool> WaitForOtherPlayer()
        {
            return await ViewManagers.GameViewManager.Current.WaitForOtherPlayer();
        }

    }
}
