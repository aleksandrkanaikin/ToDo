using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Entities;

namespace Desktop.Repository
{
    public class TaskRepository
    {

        private static ObservableCollection<TaskModel> Tasks = new ObservableCollection<TaskModel>
        {
            new TaskModel("dfsdsg", new TaskCategoryModel("vjfdhvjfjv"), "nnkjnjjonhhibhi",  "16.02.2023", 1, false),
            new TaskModel("vdbdfb", new TaskCategoryModel("fkdvfv;fdv"), "svdfcdfgvbfgf", "15.02.2023", 2, false)
        };

        public static void NewTask(TaskModel task)
        {
            Tasks.Add(task);
        }
        
        public static IEnumerable<TaskModel> GetTask()
        {
            return Tasks;
        }

        public static void NewCategory(TaskModel task)
        {
            for (int i = 0; i <= Tasks.Count; i++)
            {
                TaskCategoryRepository.NewCategory(Tasks[i].Category);
            }
        }
    }
}