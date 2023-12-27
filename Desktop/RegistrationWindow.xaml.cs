using System.Windows;
using System.Windows.Media;
using Desktop.Properties;
using Desktop.Repository;

namespace Desktop
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        #region Texboxes
        private void UserName_txb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameTxb.Text != "Введите имя пользователя") return;
            UserNameTxb.Text = "";
            UserNameTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void UserName_txb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameTxb.Text != "") return;
            UserNameTxb.Text = "Введите имя пользователя";
            UserNameTxb.Foreground = new SolidColorBrush(Colors.Gray);          }

        private void RegistrationMailTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (RegistrationMailTxb.Text != "Введите почту") return;
            RegistrationMailTxb.Text = "";
            RegistrationMailTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void RegistrationMailTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (RegistrationMailTxb.Text != "") return;
            RegistrationMailTxb.Text = "Введите почту";
            RegistrationMailTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void RegPasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (RegPasswordTxb.Text!= "Введите пароль") return;
            RegPasswordTxb.Text = "";
            RegPasswordTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void RegPasswordTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (RegPasswordTxb.Text != "") return;
            RegPasswordTxb.Text = "Введите пароль";
            RegPasswordTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void RepeatPasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordTxb.Text != "Повторите пароль") return;
            RepeatPasswordTxb.Text = "";
            RegPasswordTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void RepeatPasswordTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordTxb.Text != "") return;
            RepeatPasswordTxb.Text = "Повторите пароль";
            RepeatPasswordTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }
        #endregion

        private void GoToRegistrationBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (Validator.NameValid(UserNameTxb) == null &&
                Validator.EmailValid(RegistrationMailTxb) == null &&
                Validator.PassValid(RegPasswordTxb) == null &&
                Validator.RepeatPassValid(RegPasswordTxb, RepeatPasswordTxb) == null)
            {
                var loginUser =
                    UserRepository.Registration(UserNameTxb.Text, RegistrationMailTxb.Text, RegPasswordTxb.Text);

                if (loginUser != null)
                {
                    var wind = new MainEmptyWindow(UserNameTxb.Text);
                    wind.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь уже зарегестрирован");
                }
            }
            else
            {
                ErrorUserName.Content = Validator.NameValid(UserNameTxb);
                ErrorEmail.Content = Validator.EmailValid(RegistrationMailTxb);
                ErrorPassword.Content = Validator.PassValid(RegPasswordTxb);
                ErrorRepeatPassword.Content = Validator.RepeatPassValid(RegPasswordTxb, RepeatPasswordTxb);
            }
        }

        private void BackToStartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var wind = new LogInWindow();
            wind.Show();
            this.Close();
        }
    }
}