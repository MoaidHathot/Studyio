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
        public Task<IEnumerable<Topic>> GetALLTopicsAsync()
        {
            return Task.Run(() => (IEnumerable<Topic>)new[] {

                new Topic(Guid.NewGuid().ToString(), "Actor Model", "", 1, new DateTime(2016, 03, 01)),
                new Topic(Guid.NewGuid().ToString(), "Dependency Injection book", ""),
                new Topic(Guid.NewGuid().ToString(), "F#", "", 3),
                new Topic(Guid.NewGuid().ToString(), "TPL Data Flows", "")
            });
        }

        public Task<Topic> AddTopicAsync(Topic topic)
        {
            return Task.Run(() => topic);
        }

        public Task<Topic> RemoveTopicAsync(Topic topic)
        {
            return Task.Run(() => topic);
        }

        public Task<Topic> UpdateTopicAsync(Topic topic)
        {
            return Task.Run(() => topic);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
