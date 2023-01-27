using System.Windows;

namespace Desktop
{
    public partial class MainEmptyWindow : Window
    {
        public MainEmptyWindow()
        {
            InitializeComponent();
        }

        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CreateTaskWindow();
            window.Show();
            this.Hide();
        }
    }
}