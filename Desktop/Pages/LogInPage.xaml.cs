using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop.Properties;
using Desktop.Repository;
using Entities;

namespace Desktop.Pages
{
    public partial class LogInPage : Page
    {
        private Repository.Repository rep;
        
        public LogInPage()
        {
            this.rep = new Repository.Repository();
            InitializeComponent();
            ShowsNavigationUI = false;
            
        }
        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginUser loginUser = new LoginUser {Email = LoginMailTxb.Text, Password = LoginPasswTxb.Text};
            try
            {
                await rep.Login(loginUser);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           // await rep.Login(loginUser);
            // var statuscode = await rep.GetSuccessCode(loginUser);
            // MessageBox.Show($"{statuscode}");

            //NavigationService?.Navigate(new MainEmptyPage("Alex"));
            // if (Validator.EmailValid(LoginMailTxb) == null && 
            //     Validator.PassValid(LoginPasswTxb) == null)
            // {
            //     var loginUser = UserRepository.LogIn(LoginMailTxb.Text, LoginPasswTxb.Text);
            //
            //     if (loginUser != null) 
            //     {
            //          NavigationService?.Navigate(new MainEmptyPage(UserRepository.NameTransfer(LoginMailTxb.Text))); 
            //     }
            //     else 
            //     {
            //          MessageBox.Show("Пользователя не существует"); 
            //     } 
            // }
            // else
            // { 
            //     ErrorEmail.Content = Validator.EmailValid(LoginMailTxb);
            //     ErrorPassword.Content = Validator.PassValid(LoginPasswTxb);
            // }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegistrationPage());
        }

        #region Textboxes
        
        private void LoginMailTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginMailTxb.Text != "Введите почту") return;
            LoginMailTxb.Text = "";
            LoginMailTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LoginMailTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginMailTxb.Text != "") return;
            LoginMailTxb.Text = "Введите почту";
            LoginMailTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LoginPassw_txb_OnGotFocus(object sender, RoutedEventArgs e)
        {
           if(LoginPasswTxb.Text!="Введите пароль") return;
           LoginPasswTxb.Text = "";
           LoginPasswTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LoginPassw_txb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if(LoginPasswTxb.Text!="") return;
            LoginPasswTxb.Text = "Введите пароль";
            LoginPasswTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }
        #endregion
    }
}