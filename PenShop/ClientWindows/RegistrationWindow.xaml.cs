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
using PenShop.DataBase;

namespace PenShop.ClientWindows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        string selectedTextNameCB;        
        int typeClient = 0;
        public RegistrationWindow()
        {
            InitializeComponent();
            //TypeClientCB.ItemsSource = MainWindow.db.TypeClient.ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void RegisBtn_Click(object sender, RoutedEventArgs e)
        {
            int nounicle = 0;
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MessageBox.Show("Введите логин");
                LoginTB.ToolTip = "Введите логин";
                LoginTB.Background = Brushes.LightPink;
                PasswordTB.ToolTip = "";
                PasswordTB.Background = Brushes.Transparent;
                NameCompanyTB.ToolTip = "";
                NameCompanyTB.Background = Brushes.Transparent;
                TypeClientCB.ToolTip = "";
                TypeClientCB.Background = Brushes.Transparent;
            }
            else if(string.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                MessageBox.Show("Введите пароль");
                PasswordTB.ToolTip = "Введите пароль";
                PasswordTB.Background = Brushes.LightPink;
                LoginTB.ToolTip = "";
                LoginTB.Background = Brushes.Transparent;
                NameCompanyTB.ToolTip = "";
                NameCompanyTB.Background = Brushes.Transparent;
                TypeClientCB.ToolTip = "";
                TypeClientCB.Background = Brushes.Transparent;
            }
            else if (string.IsNullOrWhiteSpace(NameCompanyTB.Text))
            {
                MessageBox.Show("Введите название компании");
                NameCompanyTB.ToolTip = "Введите название компании";
                NameCompanyTB.Background = Brushes.LightPink;
                LoginTB.ToolTip = "";
                LoginTB.Background = Brushes.Transparent;
                PasswordTB.ToolTip = "";
                PasswordTB.Background = Brushes.Transparent;                
                TypeClientCB.ToolTip = "";
                TypeClientCB.Background = Brushes.Transparent;
            }
            else if (string.IsNullOrWhiteSpace(TypeClientCB.Text))
            {
                MessageBox.Show("Введите тип компании");
                TypeClientCB.ToolTip = "Введите тип компании";
                TypeClientCB.Background = Brushes.LightPink;
                LoginTB.ToolTip = "";
                LoginTB.Background = Brushes.Transparent;
                PasswordTB.ToolTip = "";
                PasswordTB.Background = Brushes.Transparent;
                NameCompanyTB.ToolTip = "";
                NameCompanyTB.Background = Brushes.Transparent;
            }
            else
            {
                LoginTB.ToolTip = null;
                LoginTB.Background = Brushes.Transparent;
                PasswordTB.ToolTip = "";
                PasswordTB.Background = Brushes.Transparent;
                NameCompanyTB.ToolTip = "";
                NameCompanyTB.Background = Brushes.Transparent;
                TypeClientCB.ToolTip = "";
                TypeClientCB.Background = Brushes.Transparent;
                Clients client = new Clients();
                client.IdTypeClient = typeClient;
                string nameCompany = NameCompanyTB.Text.Trim();                               
                if(client.IdTypeClient == 2 && !nameCompany.Contains("ООО") )
                {
                    nounicle++;
                    MessageBox.Show("Для юр.лиц необходима приставка ООО");
                    NameCompanyTB.ToolTip = "Введите приставку ООО";
                    NameCompanyTB.Background = Brushes.LightPink;                                      
                }               
                else if (!nameCompany.Contains("ИП") && client.IdTypeClient == 1)
                {
                    nounicle++;
                    MessageBox.Show("Для физ.лиц необходима приставка ИП");
                    NameCompanyTB.ToolTip = "Введите приставку ИП";
                    NameCompanyTB.Background = Brushes.LightPink;
                }
                else
                {
                    client.Name = NameCompanyTB.Text.Trim();
                    NameCompanyTB.ToolTip = "";
                    NameCompanyTB.Background = Brushes.Transparent;
                }               
                User user = new User();
                foreach (var log in MainWindow.db.User)
                {
                    if (log.Login.Trim() == LoginTB.Text.Trim())
                    {
                        nounicle++;
                        LoginTB.ToolTip = "Такой логин уже зарегестрирован!";
                        LoginTB.Background = Brushes.DarkRed;
                    }
                    else
                    {
                        user.Login = LoginTB.Text.Trim();
                        LoginTB.ToolTip = "";
                        LoginTB.Background = Brushes.Transparent;
                    }
                }               
                user.Password = PasswordTB.Password.Trim();
                user.IdRole = 2;
                user.IdClient = client.Id;
                if(nounicle == 0)
                {
                    MainWindow.db.User.Add(user);
                    MainWindow.db.Clients.Add(client);
                    MainWindow.db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }                
            }
        }

        private void TypeClientCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeClientCB.SelectedItem != null)
            {
                //ComboBoxItem cbi = (ComboBoxItem)(sender as ComboBox).SelectedItem;
                ComboBoxItem typeClients = (ComboBoxItem)TypeClientCB.SelectedItem;
                selectedTextNameCB = typeClients.Content.ToString();
                if (selectedTextNameCB == "Физ. Лицо")
                {
                    typeClient = 1;
                }
                if (selectedTextNameCB == "Юр. Лицо")
                {
                    typeClient = 2;
                }
            }
        }
    }
}
