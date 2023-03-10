using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Entities;

namespace Desktop
{
    public partial class CreateTaskWindow : Window
    {
        private List<SolidColorBrush> Color;
        private string userName;
        public CreateTaskWindow(string name)
        {
            InitializeComponent();
            userName = name;
            
            Color = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Lime),
                new SolidColorBrush(Colors.Red),
                new SolidColorBrush(Colors.LightBlue),
                new SolidColorBrush(Colors.Purple),
                new SolidColorBrush(Colors.Orange)
            };        }

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
                Category = new TaskCategoryModel(TaskCategoryTxb.Text, Color[random.Next(Color.Count)]), Check = false,
                Date = TaskDate.Text, Description = TaskDescriptionTxb.Text, Id = random.Next(1, 10),
                Name = TaskNameTxb.Text
            };
            
            var wind = new Main(userName, newTask);
            wind.Show();
            this.Close();
        }
    }
}