using System.Windows.Media;

namespace Entities
{
    public class TaskCategoryModel
    {
        public string CategoryName { get; set; }
        public SolidColorBrush Color { get; set; }

        public TaskCategoryModel(string categoryName, SolidColorBrush color)
        {
            this.CategoryName = categoryName;
            this.Color = color;
        }
    }
}