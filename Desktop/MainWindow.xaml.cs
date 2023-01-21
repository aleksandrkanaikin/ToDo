using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop.Properties;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.CurrentWindow = this;
        }
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Registration_btn_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow();
            window.Title = "new Window";
            window.Show();
            Manager.CurrentWindow.Hide();
        }

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
           if(LoginPassw_txb.Text!="Введите пароль") return;
           LoginPassw_txb.Text = "";
           LoginPassw_txb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LoginPassw_txb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if(LoginPassw_txb.Text!="") return;
            LoginPassw_txb.Text = "Введите пароль";
            LoginPassw_txb.Foreground = new SolidColorBrush(Colors.Gray);
        }
    }
}