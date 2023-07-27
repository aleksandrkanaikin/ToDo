using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Entities.Annotations;

namespace Entities
{
    public class TaskModel:INotifyPropertyChanged
    {
        private string name;
        private string description;
        private int date;
        private Guid id;
        private bool check;
        private string category;

        public Guid Id
        {
            get { return id;}
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get { return name;}
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description;}
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public bool IsComplited
        {
            get { return check;}
            set
            {
                check = value;
                OnPropertyChanged();
            }
        }

        public int Date
        {
            get { return date;}
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get { return category;}
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }
        // public TaskModel(string name, TaskCategoryModel category, string description, string date, int id, bool check)
        // {
        //     this.Name = name;
        //     this.Category = category;
        //     this.Description = description;
        //     this.Date = date;
        //     this.Id = id;
        //     this.Check = check;
        // }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}