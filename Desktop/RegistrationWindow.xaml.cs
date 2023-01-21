using System.Windows;

namespace Desktop
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void UserName_txb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void UserName_txb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RegistrationMailTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegistrationMailTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegPasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RegPasswordTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void GoToRegistrationBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (RegPasswordTxb.Text == null)
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                
            }
        }

        private void BackToStartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var wind = new MainWindow();
            wind.Show();
            this.Close();
        }

        private void RepeatPasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void RepeatPasswordTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
        }
    }
}