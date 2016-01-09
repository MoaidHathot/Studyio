using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio.Shared.Messages
{
    public class TopicAddedMessage : TopicMessage
    {
        public TopicAddedMessage(Topic topic) 
            : base(topic)
        {

        }
    }
}
