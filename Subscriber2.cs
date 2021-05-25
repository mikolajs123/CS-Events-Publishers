using System;

namespace EventsAndPublishers
{
	public class Subscriber2
	{
		// Słucham czy publisher wysłał powiadomienie do mnie z argmuentem
		public void OnArgumented(object source, MyEventArgs args)
		{
		    Console.WriteLine($"[Subscriber 2]: Właśnie otrzymałem powiadomienie od Publishera z argumentem: {args.Message}");
		}
	}
}
