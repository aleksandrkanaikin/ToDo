using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Desktop.Repository;
using Entities;

namespace Desktop
{
    public partial class Main : Window
    {
        private List<SolidColorBrush> Color;
        private ObservableCollection<TaskCategoryModel> Categories;
        private ObservableCollection<TaskModel> Tasks;
        
        public Main(string name)
        {
            InitializeComponent();

            UserNameTxb.Text = name;

            Color = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Lime),
                new SolidColorBrush(Colors.Red),
                new SolidColorBrush(Colors.LightBlue),
                new SolidColorBrush(Colors.Purple),
                new SolidColorBrush(Colors.Orange)
            };
            Random random = new Random();
            
            Categories= new ObservableCollection<TaskCategoryModel> 
            {
                new TaskCategoryModel("Дом", Color[random.Next(Color.Count)]),
                new TaskCategoryModel("Работа", Color[random.Next(Color.Count)]),
                new TaskCategoryModel("Учеба", Color[random.Next(Color.Count)]),
                new TaskCategoryModel("Отдых", Color[random.Next(Color.Count)])
            };
            CateogryList.ItemsSource = Categories;
            
            Tasks = new ObservableCollection<TaskModel>
            {
                new TaskModel("dfsdsg",Categories[1], "nnkjnjjonhhibhi",  "16.02.2023", 1, false),
                new TaskModel("vdbdfb", Categories[2], "svdfcdfgvbfgf", "15.02.2023", 2, false)
            };
            TaskList.ItemsSource = Tasks;


        }

        private void CateogryList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TaskList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TaskComplitedBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteTaskBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}