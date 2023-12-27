using System.Windows;

namespace Desktop
{
    public partial class CreateTaskWindow : Window
    {
        private string userName;
        public CreateTaskWindow(string name)
        {
            InitializeComponent();
            userName = name;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new MainEmptyWindow(userName);
            window.Show();
            this.Close();
        }

        private void CreateTaskBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var wind = new Main(userName);
            wind.Show();
            this.Close();
        }
    }
}