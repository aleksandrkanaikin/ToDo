using System;
using System.Net;
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
        private APIRepository rep;
        
        public LogInPage()
        {
            this.rep = new APIRepository();
            InitializeComponent();
            ShowsNavigationUI = false;
            
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegistrationPage());
        }
        
        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginUser loginApiUser = new LoginUser {Email = LoginMailTxb.Text, Password = LoginPasswTxb.Text};
            try
            {
                if (await rep.Login(loginApiUser) == null)
                {
                    MessageBox.Show("Вы успешно вошли");
                    if (await rep.GetTodosAsync() != null)
                    {
                        NavigationService?.Navigate(new MainPage("Alex"));
                    }
                    else
                    {
                        NavigationService?.Navigate(new MainEmptyPage("Alex"));
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не зарегестрирован");

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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