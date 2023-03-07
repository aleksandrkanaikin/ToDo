using System.Windows;

namespace Desktop
{
    public partial class MainEmptyWindow : Window
    {
        private string userName;
        public MainEmptyWindow(string name)
        {
            InitializeComponent();
            userName = name;
            UserNameTxb.Text = name;
        }

        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CreateTaskWindow(userName);
            window.Show();
            this.Hide();
        }
    }
}