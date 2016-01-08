using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio
{
    public class ViewModelLocator
    {
        public ITopicsViewModel TopicsPage
        {
            get { return new TopicsViewModel(); }
        }

        public IAddTopicViewModel AddTopicPage
        {
            get
            {
                return new AddTopicViewModel();
            }
        }
    }
}
