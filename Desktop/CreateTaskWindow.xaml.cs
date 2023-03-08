using System;
using System.Windows;
using System.Windows.Media;
using Entities;

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
            Random random = new Random();
            TaskModel newTask = new TaskModel
            {
                Category = new TaskCategoryModel(TaskCategoryTxb.Text, new SolidColorBrush()), Check = false,
                Date = TaskDate.Text, Description = TaskDescriptionTxb.Text, Id = random.Next(1, 10),
                Name = TaskNameTxb.Text
            };//Id = random.Next(1, 10), Category = new TaskCategoryModel(TaskCategoryTxb.Text, new SolidColorBrush()),
                 //Name = TaskNameTxb.Text, Description = TaskDescriptionTxb.Text, Check = false, Date = TaskDate.Text
            
            var wind = new Main(userName, newTask);
            wind.Show();
            this.Close();
        }
    }
}