using System;
using System.Threading;

namespace EventsAndPublishers
{
	// Normalnie ta klasa powinna być w oddzielnym pliku ale dla 
	// przejrzystości dałem ją tutaj i ta klasa słuzy do przekazywania customowych argumentów
	// jezeli chcesz przekazac inne argumenty niz string zmien te property albo dodaj dodatkowe jak int, Datetime etc...
	public class MyEventArgs : EventArgs
	{
		public string Message { get; set; }
	}

	public class Publisher
	{
		// Deklaracja delegata który informuje subscriberów
		// ale nie przesyła argumentu
		public delegate void NonArgumentEventHandler(object source, EventArgs args);

		// Deklaracja eventu który będzię używał powyższego delegata bez argumentu
		public event NonArgumentEventHandler NonArgumented;

        // Deklaracja delegata który informuje subscriberów
        // i przesyła customowy argument
        public delegate void ArgumentEventHandler(object source, MyEventArgs args);

        // Deklaracja eventu który będzię używał powyższego delegata z argumentem
        public event ArgumentEventHandler Argumented;


        // Powyzsze delegaty i eventy mozna rowniez w c# napisac tak jak ponizej
		// natomiast wyzej napisalem te podstawowa wersje abys wiedzial jak to dziala
		// od strony kuchni.
		// To:
        // ` 
        		// public event EventHandler<EventArgs> NonArgumented;
        // `
        // Zamiast:
        // `
        //		public delegate void NonArgumentEventHandler(object source, EventArgs args);
        //		public event NonArgumentEventHandler NonArgumented;
        // `
        // Oraz:
        // ` 
        		// public event EventHandler<MyEventArgs> Argumented;
        // `
        // Zamiast:
        // `
        //		public delegate void ArgumentEventHandler(object source, MyEventArgs args);
        //		public event ArgumentEventHandler Argumented;
        // `
		//
		// Zakomentuj kod od lini 17 włacznie do lini 27 włacznie i Odkomentuj linie 34 oraz 43
		// i zobacz ze program bedzie działać tak samo

        public void DoSomething()
		{
			Console.WriteLine("coś robię...");
			Thread.Sleep(3000);

			// Wywołuje event do subscriberów żeby ich poinformować bez argumentu
			OnNonArgumented();

            // Wywołuje event do subscriberów żeby ich poinformować z argumentem
            OnArgumented("moja wiadomość");
		}

		// Metodą informująca subcriberów bez argumentu
		// z reguły dajemy te metody jako protected virtual bo taka jest konwencja
		protected virtual void OnNonArgumented()
		{
			if (NonArgumented != null)
				NonArgumented(this, EventArgs.Empty);
		}

        // Metodą informująca subcriberów z argumentem
        // z reguły dajemy te metody jako protected virtual bo taka jest konwencja
        protected virtual void OnArgumented(string message)
        {
            if (Argumented != null)
                Argumented(this, new MyEventArgs { Message = message });
        }
	}
}