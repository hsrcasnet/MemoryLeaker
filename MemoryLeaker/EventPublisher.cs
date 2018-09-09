using System;

namespace MemoryLeaker
{
    internal class EventPublisher
    {
        public event EventHandler<Guid> SomeEvent;

        public void PublishEvents()
        {
            var guid = Guid.NewGuid();
            Console.WriteLine($"{nameof(EventPublisher)}: PublishEvents sends {guid}");
            this.SomeEvent?.Invoke(this, guid);
        }
    }
}