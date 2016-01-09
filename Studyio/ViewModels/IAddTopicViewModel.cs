using Studyio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Studyio
{
    public interface IAddTopicViewModel
    {
        string TopicName { get; set; }
        DateTime? DueDate { get; set; }
        int Priority { get; set; }

        ICommand AcceptCommand { get; }

        void EvaluateSaveTopicCommand();

        bool IsEditMode { get; }

        Topic CurrentTopic { get; set; }
    }
}
