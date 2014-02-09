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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            ViewManagers.GameViewManager gameViewManager = new ViewManagers.GameViewManager();
            gameViewManager.Start(textboxPlayerName.Text);
            ViewManagers.GameViewManager.Current = gameViewManager;
            this.DataContext = ViewManagers.GameViewManager.Current;

            new WaitingWindow().Show();
            this.Close();
        }
    }
}
