using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Entities;

namespace Desktop.Repository
{
    public class TaskCategoryRepository
    {
        public static List<SolidColorBrush> ColorBrushes = new List<SolidColorBrush>
        {
            new SolidColorBrush(Colors.Lime),
            new SolidColorBrush(Colors.Orange),
            new SolidColorBrush(Colors.Purple),
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.Blue)
        };

        Random _random = new Random();
        
        public static ObservableCollection<TaskCategoryModel> Categories = new ObservableCollection<TaskCategoryModel>
        {
            new TaskCategoryModel("Дом", ColorBrushes[_random.Next(ColorBrushes.Count)]),
            new TaskCategoryModel("Работа", ColorBrushes[_random.Next(ColorBrushes.Count)]),
            new TaskCategoryModel("Учеба", ColorBrushes[_random.Next(ColorBrushes.Count)]),
            new TaskCategoryModel("Отдых", ColorBrushes[_random.Next(ColorBrushes.Count)])
        };

        

        public static void NewCategory(TaskCategoryModel category)
        {
            foreach (var item in Categories)
            {
                if (item != category)
                {
                    Categories.Add(category);
                }
            }
        }
    }
}