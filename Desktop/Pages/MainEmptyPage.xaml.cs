using System.Windows;
using System.Windows.Controls;

namespace Desktop.Pages
{
    public partial class MainEmptyPage : Page
    {
        private string userName;
        public MainEmptyPage(string name)
        {
            InitializeComponent();
            userName = name;
            UserNameTxb.Text = name;
        }
        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTaskPage(userName));
        }
    }
}