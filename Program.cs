using System;

namespace EventsAndPublishers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            var publisher = new Publisher();
            var subscriber1 = new Subscriber1();
            var subscriber2 = new Subscriber2();

            // Subscriber1 zaczyna nasłuchiwać na dany event u publishera bez customowego argumentu
            publisher.NonArgumented += subscriber1.OnNonArgumented;

            // Subscriber2 zaczyna nasłuchiwać na dany event u publishera z customowym argumentem
            publisher.Argumented += subscriber2.OnArgumented;

            // Publisher wywołuje jakąś funckje i gdy funkcja się skónczy publisher poinformuje subscriberów
            publisher.DoSomething();
        }
    }
}
