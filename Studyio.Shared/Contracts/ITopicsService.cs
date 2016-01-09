using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyio.Shared.Contracts
{
    public interface ITopicsService : IDisposable
    {
        Task<IEnumerable<Topic>> GetALLTopicsAsync();
        Task<Topic> AddTopicAsync(Topic topic);
        Task<Topic> UpdateTopicAsync(Topic topic);
        Task<Topic> RemoveTopicAsync(Topic topic);
    }
}
