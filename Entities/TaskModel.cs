using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Entities.Annotations;

namespace Entities
{
    public class TaskModel
    {
       /* public string name;
        public string description;
        public string date;
        public int id;
        public bool check;*/

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool Check { get; set; }

        public string Date { get; set; }
        public TaskCategoryModel Category { get; set; }
        public TaskModel(string name, TaskCategoryModel category, string description, string date, int id, bool check)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Date = date;
            this.Id = id;
            this.Check = check;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}