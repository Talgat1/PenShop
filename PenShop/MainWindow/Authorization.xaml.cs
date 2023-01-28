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
using PenShop.DataBase;
using PenShop.ClientWindows;
using PenShop.AdminWindows;

namespace PenShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PenShopEntities db = new PenShopEntities();
        public static User userauth;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int unicle = 0;
            LoginTB.Background = Brushes.Transparent;
            LoginTB.ToolTip = "";
            PasswordTB.Background = Brushes.Transparent;
            PasswordTB.ToolTip = "";
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MessageBox.Show("Введите все значения!");                
                LoginTB.ToolTip = "Введите логин";
                LoginTB.Background = Brushes.LightPink;
            }
            else if (string.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                MessageBox.Show("Введите все значения!");
                PasswordTB.ToolTip = "Введите пароль";
                PasswordTB.Background = Brushes.LightPink;
            }
            else
            {
                foreach (var user in db.User)
                {
                    if (user.Login == LoginTB.Text.Trim() && user.IdRole == 2)
                    {
                        unicle++;
                        if (user.Password == PasswordTB.Password.Trim())
                        {
                            LoginTB.Background = Brushes.Transparent;
                            LoginTB.ToolTip = "";
                            PasswordTB.Background = Brushes.Transparent;
                            PasswordTB.ToolTip = "";
                            MessageBox.Show($"Добро пожаловать в приложение PenShop");
                            userauth = user;
                            WindowPen winPen = new WindowPen();
                            this.Close();
                            winPen.Show();
                        }
                        else
                        {
                            PasswordTB.ToolTip = "Неверный пароль попробуйте еще раз!";
                            PasswordTB.Background = Brushes.LightPink;
                        }
                    }                    
                    else if(user.Login == LoginTB.Text.Trim() && user.IdRole == 1)
                    {
                        unicle++;
                        if (user.Password == PasswordTB.Password.Trim())
                        {
                            LoginTB.Background = Brushes.Transparent;
                            LoginTB.ToolTip = "";
                            PasswordTB.Background = Brushes.Transparent;
                            PasswordTB.ToolTip = "";
                            MessageBox.Show($"Добро пожаловать в приложение Адимин");
                            userauth = user;
                            FrameAuth.NavigationService.Navigate(new PageAdmin());
                            //PageAdmin mp = new PageAdmin();
                            //this.Close();
                            //mp.S
                        }
                        else
                        {
                            PasswordTB.ToolTip = "Неверный пароль попробуйте еще раз!";
                            PasswordTB.Background = Brushes.LightPink;
                        }
                    }
                    else if(unicle == 0)
                    {
                        //MessageBox.Show("Неверный логин попробуйте еще раз!");
                        LoginTB.ToolTip = "Неверный логин попробуйте еще раз!";
                        LoginTB.Background = Brushes.LightPink;
                    }
                    else
                    {
                        LoginTB.Background = Brushes.Transparent;
                        LoginTB.ToolTip = "";
                    }

                }                
            }
        }

        private void RegisBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regisWin = new RegistrationWindow();
            this.Close();
            regisWin.Show();
        }
    }
}
