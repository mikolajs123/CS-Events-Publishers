using System;

namespace EventsAndPublishers
{
	public class Subscriber1
	{
        // Słucham czy publisher wysłał powiadomienie do mnie bez argmuentu
        public void OnNonArgumented(object source, EventArgs args)
		{
			Console.WriteLine($"[Subscriber 1]: Właśnie otrzymałem powiadomienie od Publishera bez argumentu");
		}
	}
}