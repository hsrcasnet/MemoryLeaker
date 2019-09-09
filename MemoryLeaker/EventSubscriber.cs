using System;
using System.Collections;
using System.Collections.Generic;

namespace MemoryLeaker
{
    internal class EventSubscriber : IDisposable
    {
        private readonly int id;
        private readonly ICollection<Guid> collectedGuids;
        private readonly EventPublisher eventPublisher;

        public EventSubscriber(EventPublisher eventPublisher, int id)
        {
            this.collectedGuids = new List<Guid>();
            this.id = id;
            this.eventPublisher = eventPublisher;
            this.eventPublisher.SomeEvent += this.OnSomeEvent;
        }

        private void OnSomeEvent(object sender, Guid guid)
        {
            this.collectedGuids.Add(guid);

            Logger.WriteLine($"{nameof(EventSubscriber)} {id}: OnSomeEvent received {{{guid}}}");
        }

        public void Dispose()
        {
            this.eventPublisher.SomeEvent -= this.OnSomeEvent;
        }
    }
}