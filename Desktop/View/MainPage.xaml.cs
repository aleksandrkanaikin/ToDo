using Desktop.Model;
using Desktop.Repository;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static bool isCheked;
        private ObservableCollection<CategoryModel> TasksCategory { get; set; }
        private List<SolidColorBrush> Colors { get; set; }
        public MainPage(string name = "")
        {
            InitializeComponent();
            Colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(System.Windows.Media.Colors.Lime),
                new SolidColorBrush(System.Windows.Media.Colors.Red),
                new SolidColorBrush(System.Windows.Media.Colors.LightBlue),
                new SolidColorBrush(System.Windows.Media.Colors.Purple),
            };


            TasksCategory = new ObservableCollection<CategoryModel>
            {
                new CategoryModel {Title = "Дом", TitleColor = Colors[0]},
                new CategoryModel {Title = "Учеба", TitleColor = Colors[1]},
                new CategoryModel {Title = "Отдых", TitleColor = Colors[2]},
                new CategoryModel {Title = "Работа", TitleColor = Colors[3]},
            };
            ApiService.GetTasks();
            TaskCategoryListBox.ItemsSource = TasksCategory;
            TasksListBox.ItemsSource = ApiService.Tasks;
        }

        private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new CreatePage();
            NavigationService.Navigate(page);
        }

        private async void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksListBox.SelectedItem;
            if (await ApiService.DeleteTaskAsync(task))
            {
                TasksListBox.ItemsSource = ApiService.Tasks;
            }
        }

        private void TasksListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = (TaskModel)TasksListBox.SelectedItem;

            DetailDescriptionBlock.Visibility = Visibility.Visible;

            if (task != null)
            {
                TitleTextBlock.Text = task.Title;
                ContentTextBlock.Text = task.Content;
                TimeTextBlock.Text = task.Time;
                DateTextBlock.Text = task.Date.ToString();
            }
            else
            {
                DetailDescriptionBlock.Visibility = Visibility.Hidden;
            }
        }

        private async void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(await ApiService.PutTaskAsync((TaskModel)TasksListBox.SelectedItem))
            {
                ((TaskModel)TasksListBox.SelectedItem).IsChecked = true;
                DetailDescriptionBlock.Visibility = Visibility.Hidden;
            }

        }

        private void TasksConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isCheked = false;
            TasksListBox.ItemsSource = ApiService.Tasks.Where(t => t.IsChecked == isCheked);
        }

        private void HistoryConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isCheked = true;
            TasksListBox.ItemsSource = ApiService.Tasks.Where(t => t.IsChecked == isCheked);
        }

        private void TaskListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
