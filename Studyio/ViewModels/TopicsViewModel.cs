using GalaSoft.MvvmLight;
using Studyio.DataAccess;
using Studyio.Shared;
using Studyio.Shared.Contracts;
using Studyio.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio
{
    public class TopicsViewModel : StudyioViewModelBase, ITopicsViewModel
    {
        private ObservableCollection<Topic> _topics;
        private ObservableCollection<Topic> _closedTopics;

        public ObservableCollection<Topic> Topics { get { return _topics; } set { Set(value, ref _topics); } }
        public ObservableCollection<Topic> DoneTopics { get { return _closedTopics; } set { Set(value, ref _closedTopics); } }

        private ITopicsService _topicService;

        public TopicsViewModel()
        {
            _topicService = new LocalTopicsService();

            _topics = new ObservableCollection<Topic>();
            _closedTopics = new ObservableCollection<Topic>();

            MessengerInstance.Register<TopicAddedMessage>(this, (t) => HandleTopicAdded(t.Topic));
            MessengerInstance.Register<TopicUpdatedMessage>(this, (t) => HandleTopicUpdated(t.Topic));
        }

        private void HandleTopicAdded(Topic topic)
        {
            if (topic.IsDone)
            {
                _closedTopics.Add(topic);
            }
            else
            {
                _topics.Add(topic);
            }
        }

        private void HandleTopicUpdated(Topic topic)
        {
            if (_topics.Contains(topic))
            {
                var found = _topics.Single((t) => t.Key == topic.Key);

                if (topic.IsDone)
                {
                    _topics.Remove(found);
                    _closedTopics.Add(topic);
                }
                else
                {
                    found.Description = topic.Description;
                    found.DueDate = topic.DueDate;
                    found.Priority = topic.Priority;
                    found.Title = topic.Title;
                }
            }
            else if(_closedTopics.Contains(topic))
            {
                var found = _closedTopics.Single((t) => t.Key == topic.Key);

                if (topic.IsDone)
                {
                    found.Description = topic.Description;
                    found.DueDate = topic.DueDate;
                    found.Priority = topic.Priority;
                    found.Title = topic.Title;
                }
                else
                {
                    _closedTopics.Remove(found);
                    _topics.Add(topic);
                }
            }
        }

        public async Task ReloadTopicsAsync()
        {
            var topics = await _topicService.GetALLTopicsAsync();

            Topics.Clear();

            foreach (var t in topics.Where(t => !t.IsDone).OrderByDescending(t => t.Priority).OrderByDescending(t => t.DueDate))
            {
                Topics.Add(t);

                //    var found = Topics.SingleOrDefault(ft => ft.Key == t.Key);

                //    if (null != found)
                //    {
                //        found.IsDone = t.IsDone;
                //        found.Description = t.Description;
                //        found.DueDate = t.DueDate;
                //        found.Priority = t.Priority;
                //        found.Title = t.Title;
                //    }
                //    else
                //    {
                //Topics.Add(t);
                //}
            }

            DoneTopics.Clear();

            foreach (var t in topics.Where(t => t.IsDone).OrderByDescending(t => t.DueDate))
            {
                DoneTopics.Add(t);

                //var found = DoneTopics.SingleOrDefault(ft => ft.Key == t.Key);

                //if (null != found)
                //{
                //    found.IsDone = t.IsDone;
                //    found.Description = t.Description;
                //    found.DueDate = t.DueDate;
                //    found.Priority = t.Priority;
                //    found.Title = t.Title;
                //}
                //else
                //{
                //    DoneTopics.Add(t);
                //}
            }
        }
    }
}
