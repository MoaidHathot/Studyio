using Studyio.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studyio.Shared;

namespace Studyio.DataAccess
{
    public class LocalTopicsService : ITopicsService
    {
        public Task<Topic> AddTopicAsync(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetALLTopicsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> RemoveTopicAsync(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> UpdateTopicAsync(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
