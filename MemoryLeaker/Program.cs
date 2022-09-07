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

            // DEMO: For the purpose of this demo, we're happy with 10 subscribers
            // --> Increase the number to 100 or 1000 and see how quickly memory is allocated (and never released again)!
            const int numberOfSubscribers = 10;

            Console.WriteLine($"subscriptions: {numberOfSubscribers}");

            var publisher = new EventPublisher();

            for (var i = 0; i < numberOfSubscribers; i++)
            {
                var subscriber = new EventSubscriber(publisher, i);
                subscriber.Subscribe();

                publisher.PublishEvents();

                // DEMO: What happens if we forget to unsubscribe from event subscriptions?
                // --> Remove following method Unsubscribe() in order to produce a memory leak
                // --> Add method Unsubscribe() in order to properly unsubscribe all event handlers
                subscriber.Unsubscribe();

                subscriber = null;
                Console.WriteLine($"------------");
            }

            // DEMO: Force GC to collect unused memory (Used for demo purposes only!)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine();
            Console.WriteLine($"GC.Collect finished");

            Console.ReadKey();
        }
    }
}