using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop.Properties;
using Desktop.Repository;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInWindow
    {
        public LogInWindow()
        {
            InitializeComponent();
            Manager.CurrentWindow = this;
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.EmailValid(LoginMailTxb) == null && 
                Validator.PassValid(LoginPasswTxb) == null)
            {
                var loginUser = UserRepository.LogIn(LoginMailTxb.Text, LoginPasswTxb.Text);
            
                if (loginUser != null)
                {
                    var wind = new MainEmptyWindow(UserRepository.NameTranfer(LoginMailTxb.Text));
                    wind.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователя не существует");
                }
            
            }
            else
            {
                ErrorEmail.Content = Validator.EmailValid(LoginMailTxb);
                ErrorPassword.Content = Validator.PassValid(LoginPasswTxb);
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow();
            window.Title = "new Window";
            window.Show();
            Manager.CurrentWindow.Hide();
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