using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Studyio
{
    public class AddTopicViewModel : StudyioViewModelBase, IAddTopicViewModel
    {
        private string _topicName;
        private string _topicDescription;
        private int _priority;
        private DateTime? _dueDate;

        private RelayCommand _acceptCommand;

        public AddTopicViewModel()
        {
            _acceptCommand = new RelayCommand(() => { }, () => !string.IsNullOrWhiteSpace(_topicName));
        }

        public string TopicName { get { return _topicName; } set { Set(value, ref _topicName); } }
        public string TopicDescription { get { return _topicDescription; } set { Set(value, ref _topicDescription); } }
        public DateTime? DueDate { get { return _dueDate; } set { Set(value, ref _dueDate); } }
        public int Priority { get { return _priority; } set { Set(value, ref _priority); } }

        public ICommand AcceptCommand { get { return _acceptCommand; } }

        public void EvaluateSaveTopicCommand()
        {
            _acceptCommand.RaiseCanExecuteChanged();
        }
    }
}
