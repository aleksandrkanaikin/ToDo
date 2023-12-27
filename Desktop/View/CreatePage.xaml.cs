using Desktop.Model;
using Desktop.Repository;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        private bool _isExiting = false;
        private string _name;
        public CreatePage(string name = "")
        {
            InitializeComponent();
            _name = name;
            var pageEnterAnimation = (Storyboard)FindResource("PageEnterAnimation");
            if (pageEnterAnimation != null)
            {
                pageEnterAnimation.Completed += (sender, e) =>
                {
                    _isExiting = false;
                };
                pageEnterAnimation.Begin(PageContainer);
            }
        }
        private async void CreateTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                if (Category.Text != "")
                {
                    if (Description.Text != "")
                    {
                        if (DatePicker.Text != "")
                        {
                            if (Time.Text != "")
                            {
                                var task = new TaskModel
                                {

                                    Title = Name.Text,
                                    Category = Category.Text,
                                    Content = Description.Text,
                                    Date = DatePicker.SelectedDate,
                                    Time = Time.Text,
                                    IsChecked = false,
                                    BackgroundColor = Brushes.White,
                                    ColorBorder = Brushes.Blue
                                };

                                if (await ApiService.CreateTask(task))
                                {
                                   
                                    var mainPage = new MainPage(_name);
                                    NavigationService.Navigate(mainPage);
                                }
                                else
                                {
                                    MessageBox.Show("Какая то ошибка");
                                }
                                

                            }
                            else
                            {
                                MessageBox.Show("Неправильный формат ввода времени");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неправильный формат ввода даты");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле описания пустое");
                    }
                }
                else
                {
                    MessageBox.Show("Поле категории пустое");
                }
            }
            else
            {
                MessageBox.Show("Поле названия задачи пустое");
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isExiting)
            {
                _isExiting = true;

                var pageExitAnimation = (Storyboard)FindResource("PageExitAnimation");
                if (pageExitAnimation != null)
                {
                    pageExitAnimation.Completed += (s, ev) =>
                    {
                        var page = new MainPage();
                        NavigationService.Navigate(page);
                    };
                    pageExitAnimation.Begin(PageContainer);
                }
            }
        }
    }
}
