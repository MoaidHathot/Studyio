using GalaSoft.MvvmLight;
using Studyio.Shared;
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

        public ObservableCollection<Topic> ClosedTopics
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TopicsViewModel()
        {
            _topics = new ObservableCollection<Topic>(new[] {

                new Topic(Guid.NewGuid().ToString(), "Actor Model", "", 1, new DateTime(2016, 03, 01)),
                new Topic(Guid.NewGuid().ToString(), "Dependency Injection book", ""),
                new Topic(Guid.NewGuid().ToString(), "F#", "", 3),
                new Topic(Guid.NewGuid().ToString(), "TPL Data Flows", "")
            }.OrderByDescending(t => t.Priority).OrderByDescending(t => t.DueDate));

            _closedTopics = new ObservableCollection<Topic>(new[] {

                new Topic(Guid.NewGuid().ToString(), "Task-Parallel Library", "", 1, new DateTime(2015, 03, 01)),
                new Topic(Guid.NewGuid().ToString(), "ASP.Net", ""),
                new Topic(Guid.NewGuid().ToString(), "MVVM Light", "", 10, new DateTime(2015, 01, 03)),
            }.OrderByDescending(t => t.DueDate));
        }
    }
}
