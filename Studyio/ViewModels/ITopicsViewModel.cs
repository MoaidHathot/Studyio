using Studyio.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio
{
    public interface ITopicsViewModel
    {
        ObservableCollection<Topic> Topics { get; set; }
        ObservableCollection<Topic> ClosedTopics { get; set; }
    }
}
