using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Studyio.DataAccess;
using Studyio.Shared;
using Studyio.Shared.Contracts;
using Studyio.Shared.Messages;
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
        private int _priority = 1;
        private DateTime? _dueDate;

        private RelayCommand _acceptCommand;

        private Topic _topic;

        private ITopicsService _topicService;

        public AddTopicViewModel()
            : this(null)
        {
            Priority = 1;
        }

        public AddTopicViewModel(Topic topic)
        {
            _topicService = new LocalTopicsService();

            CurrentTopic = topic;

            _acceptCommand = new RelayCommand(async () => await SaveButtonPressed(), () => !string.IsNullOrWhiteSpace(_topicName));

            FromTopic(topic);
        }

        public string TopicName { get { return _topicName; } set { Set(value, ref _topicName); } }
        public string TopicDescription { get { return _topicDescription; } set { Set(value, ref _topicDescription); } }
        public DateTime? DueDate { get { return _dueDate; } set { Set(value, ref _dueDate); } }
        public int Priority { get { return _priority; } set { Set(value, ref _priority); } }

        public ICommand AcceptCommand { get { return _acceptCommand; } }

        public bool IsEditMode
        {
            get
            {
                return null != _topic;
            }
        }

        public Topic CurrentTopic { get { return _topic; } set { FromTopic(value); Set(() => _topic, ref _topic, value); } }

        public void EvaluateSaveTopicCommand()
        {
            _acceptCommand.RaiseCanExecuteChanged();
        }

        private void FromTopic(Topic topic)
        {

            if (null != topic && _topic != topic)
            {
                TopicName = topic.Title;
                TopicDescription = topic.Description;
                Priority = topic.Priority;
                DueDate = topic.DueDate;
            }

            TopicName = "";
            TopicDescription = "";
            Priority = 1;
            DueDate = null;

            _topic = null;
        }

        private async Task SaveButtonPressed()
        {
            if (null != _topic)
            {
                await _topicService.UpdateTopicAsync(_topic);

                MessengerInstance.Send(new TopicUpdatedMessage(_topic));
            }
            else
            {

                var topic = new Topic(Guid.NewGuid().ToString(), TopicName, TopicDescription, Priority, DueDate);

                await _topicService.AddTopicAsync(topic);

                MessengerInstance.Send(new TopicAddedMessage(topic));
            }

            FromTopic(null);
        }
    }
}
