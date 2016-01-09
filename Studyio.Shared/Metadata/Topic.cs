using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio.Shared
{
    public class Topic : ObservableObject
    {
        private string _title;
        private int _priority;
        private DateTime? _dueDate;
        private bool _isDone;

        private string _description;

        private string _key;

        public string Key { get { return _key; } set { Set(() => _key, ref _key, value); } }
        public string Title { get { return _title; } set { Set(() => _title, ref _title, value); } }
        public string Description { get { return _description; } set { Set(() => _description, ref _description, value); } }
        public int Priority { get { return _priority; } set { Set(() => _priority, ref _priority, value); } }
        public DateTime? DueDate { get { return _dueDate; } set { Set(() => _dueDate, ref _dueDate, value); } }
        public bool IsDone { get { return _isDone; } set { Set(() => _isDone, ref _isDone, value); } }

        //public string Key { get; set; }

        public Topic(string key, string title, string description, int priority = 1, DateTime? dueDate = null)
        {
            this.Key = key;

            _title = title;
            _description = description;
            _priority = priority;
            _dueDate = dueDate;
        }

        public override string ToString()
        {
            return $"{Priority} - {Title}{(null == _dueDate ? string.Empty : " Due to " + _dueDate)}";
        }

        public override bool Equals(object obj)
        {
            var casted = obj as Topic;

            if (null == casted)
            {
                return false;
            }

            return Key == casted.Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
