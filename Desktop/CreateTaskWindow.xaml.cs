using System.Windows;

namespace Desktop
{
    public partial class CreateTaskWindow : Window
    {
        public CreateTaskWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new MainEmptyWindow();
            window.Show();
            this.Close();
        }
    }
}