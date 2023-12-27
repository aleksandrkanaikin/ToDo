using Desktop.Model;
using Desktop.Repository;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Voiti(object sender, RoutedEventArgs e)
        {

            if (Validator.EmailValid(Login) == false)
            {
                MessageBox.Show("Неккоректный ввод почты");
            }
            else
            {
                if (Validator.PasswordValid(PasswordBox) == false)
                {
                    MessageBox.Show("Неккоректный ввод пароля");
                }
                else
                {
                    UserModel user = new UserModel(Login.Text, PasswordBox.Password);
                    if (await ApiService.LogInAsync(user))
                    {
                        var wind = new MainPage();
                        NavigationService.Navigate(wind);
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль или логин");
                    }
                    
                }
            }
        }
        private void Registracia(object sender, RoutedEventArgs e)
        {
            RegisterPage reg = new RegisterPage();
            NavigationService.Navigate(reg);
        }
        private void vid(object sender, RoutedEventArgs e)
        {
            passv.Text = PasswordBox.Password;
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                passv.Text = PasswordBox.Password;
                passv.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Hidden;
                PasswordBox.Password = passv.Text;

            }
            else
            {
                passv.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Visible;
                passv.Text = PasswordBox.Password;
                PasswordBox.Password = passv.Text;

            }

        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    public static class Validator
    {
        public static bool EmailValid(TextBox Login)
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(Login.Text);

            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool PasswordValid(PasswordBox PasswordBox)
        {
            if (PasswordBox.Password.Length >= 6)
                return true;
            else
                return false;
        }
        public static bool Name(TextBox name)
        {
            if (name.Text.Length >= 3)
                return true;
            else
                return false;
        }
        public static bool PochtaValid(TextBox pochta)
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            Match match = regex.Match(pochta.Text);

            if (match.Success)
                return true;
            else
                return false;
        }
        public static bool PassregValid(TextBox passreg)
        {
            if (passreg.Text.Length >= 6)
                return true;
            else
                return false;
        }
        public static bool PassregandpovtValid(TextBox passregpovt, TextBox passreg)
        {
            if (passregpovt.Text == passreg.Text)
                return true;
            else
                return false;
        }
    }
}
