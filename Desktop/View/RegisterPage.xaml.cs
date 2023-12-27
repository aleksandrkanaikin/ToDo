using Desktop.Model;
using Desktop.Repository;
using Desktop.Services;
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

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void ZaregAsync(object sender, RoutedEventArgs e)
        {
            if (Validator.Name(name) == false)
            {
                MessageBox.Show("Неккоректный ввод имени");
            }
            else
            {
                if (Validator.PochtaValid(pochta) == false)
                {
                    MessageBox.Show("Неккоректный ввод почты");
                }
                else
                {
                    if (Validator.PassregValid(passreg) == false)
                    {
                        MessageBox.Show("Неккоректный ввод пароля");
                    }
                    else
                    {
                        if (Validator.PassregandpovtValid(passregpovt, passreg) == false)
                        {
                            MessageBox.Show("Пароли не повтряются");
                        }
                        else
                        {
                            var registerUser = new UserModel(name.Text, pochta.Text, passreg.Text);
                            if (await ApiService.RegistrationAsync(registerUser))
                            {
                                var page3 = new MainEmptyPage();
                                NavigationService.Navigate(page3);
                            }
                            else
                            {
                                MessageBox.Show("Email уже занят");
                            }
                        }
                    }
                }
            }
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            LoginPage glavmenu = new LoginPage();
            NavigationService.Navigate(glavmenu);
        }

        private void name_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
