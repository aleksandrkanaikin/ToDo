using System.Windows;
using Desktop.Pages;

namespace Desktop
{
    public partial class Main2 : Window
    {
        public Main2()
        {
            InitializeComponent();
            MainControl.Content = new LogInPage();
            
        }
    }
}