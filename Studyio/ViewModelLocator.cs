using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio
{
    public class ViewModelLocator
    {
        private Lazy<AddTopicViewModel> AddTopicViewModel = new Lazy<AddTopicViewModel>(() => new AddTopicViewModel());
        private Lazy<TopicsViewModel> TopicsViewModel = new Lazy<TopicsViewModel>(() => new TopicsViewModel());

        public ITopicsViewModel TopicsPage
        {
            get { return TopicsViewModel.Value; }
        }

        public IAddTopicViewModel AddTopicPage
        {
            get
            {
                return AddTopicViewModel.Value;
            }
        }
    }
}
