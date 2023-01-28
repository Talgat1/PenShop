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

namespace PenShop.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            //ListPen.ItemsSource = MainWindow.db.Pen.ToList();
            ListPen.Visibility = Visibility.Collapsed;
        }
        private void MenuBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Collapsed;
        }

        private void ShowMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuGrid.Visibility = Visibility.Visible;
        }        
        private void MainListPage_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.NavigationService.Navigate(new WindowAdmin());
            //WindowAdmin df = new WindowAdmin();
            //df.Show();
            ListPen.Visibility = Visibility.Collapsed;
        }

        private void TovarBtn_Click(object sender, RoutedEventArgs e)
        {
            ListPen.Visibility = Visibility.Visible;
        }
    }
}
