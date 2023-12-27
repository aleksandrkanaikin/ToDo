using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Desktop.Model;

namespace Desktop.Repository
{
    public static class TasksRepository
    {
        private static readonly ObservableCollection<TaskModel> Tasks = new ObservableCollection<TaskModel>
        {

        };

        public static bool GetIsCheckedTask(TaskModel task)
        {
            return task.IsChecked;
        }

        public static ObservableCollection<TaskModel> GetTasksIsChecked(bool isChecked)
        {
            var tasks = new ObservableCollection<TaskModel>();
            if (isChecked)
            {
                foreach (var task in Tasks)
                {
                    if (task.IsChecked)
                    {
                        tasks.Add(task);
                    }
                }
            }
            else
            {
                foreach (var task in Tasks)
                {
                    if (!task.IsChecked)
                    {
                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        public static ObservableCollection<TaskModel> GetTasks()
        {
            return Tasks;
        }

        public static void AddTask(TaskModel task)
        {
            Tasks.Add(task);
        }

        public static void AddAllTasks(List<TaskModel> tasks)
        {
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        public static void DeleteTask(TaskModel task)
        {
            Tasks.Remove(task);
        }

        public static void IsCheckedTask(TaskModel task)
        {
            task.IsChecked = true;
        }
    }
}