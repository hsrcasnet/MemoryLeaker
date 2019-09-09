using System;

namespace MemoryLeaker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Logger.IsEnabled = true;

            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            const bool unsubscribe = false;
            const int subscriptions = 1000;

            Console.WriteLine($"subscriptions: {subscriptions}");

            var eventPublisher = new EventPublisher();

            for (var i = 0; i < subscriptions; i++)
            {
                var eventSubscriber = new EventSubscriber(eventPublisher, i);

                eventPublisher.PublishEvents();

                if (unsubscribe)
                {
                    eventSubscriber.Dispose();
                }

                eventSubscriber = null;

                Console.WriteLine($"------------");
            }

            // Force collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadKey();
        }
    }
}