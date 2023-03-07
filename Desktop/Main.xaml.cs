﻿using System;
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
        private ObservableCollection<TaskModel> ComplitedTasks;

        
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
                new TaskModel{Id = 1, Name = "Go fishing with Stephen", Category = Categories[0], 
                    Description = "Lorem ipsum dolor sit amet,consectetur adipiscing.", Date = "16.02.2023", Check = true},
                new TaskModel{Id = 1, Name = "Go fishing with Stephen", Category = Categories[2], 
                    Description = "Lorem ipsum dolor sit amet,consectetur adipiscing.", Date = "16.02.2023", Check = false},
                new TaskModel{Id = 1, Name = "Go fishing with Stephen", Category = Categories[1], 
                    Description = "Lorem ipsum dolor sit amet,consectetur adipiscing.", Date = "16.02.2023", Check = false},
                new TaskModel{Id = 1, Name = "Go fishing with Stephen", Category = Categories[3], 
                    Description = "Lorem ipsum dolor sit amet,consectetur adipiscing.", Date = "16.02.2023", Check = false},
                new TaskModel{Id = 1, Name = "Go fishing with Stephen", Category = Categories[2], 
                    Description = "Lorem ipsum dolor sit amet,consectetur adipiscing.", Date = "16.02.2023", Check = false}
            };
            TaskList.ItemsSource = Tasks;
        }

        private void CateogryList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TaskList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskModel task)
            {
                TaskNameTxb.Text = task.Name;
                TaskDateTxb.Text = task.Date;
                TaskDescriptionTxb.Text = task.Description;
                TaskFullDescription.Visibility = Visibility.Visible;
            }
            else TaskFullDescription.Visibility = Visibility.Hidden;
        }

        private void TaskComplitedBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TaskModel task = (TaskModel) TaskList.SelectedItem;
            task.Check = true;
            
        }

        private void DeleteTaskBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TaskModel task = (TaskModel) TaskList.SelectedItem;
            Tasks.Remove(task);
        }

        private void TasksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
            TaskList.ItemsSource = Tasks;
        }

        private void HistoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ComplitedTasks = new ObservableCollection<TaskModel>();
            foreach (var task in Tasks)
            {
                if (task.Check == true)
                {
                    ComplitedTasks.Add(task);
                }
            }
            
            TaskList.ItemsSource = ComplitedTasks;
        }
    }
}