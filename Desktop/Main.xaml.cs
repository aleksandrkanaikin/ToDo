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
            
            
        }
        
    }
}