using System;
using System.Threading;

namespace Bagagesortering
{
    public class Reception
    {
        public Guid ID { get; set; }
        public bool IsOpen { get; private set; } = true;
        private readonly Flight[] _flights;
        private readonly object _magicLock = new object();

        public Reception(Guid id, Flight[] flights)
        {
            ID = id;
            _flights = flights;

            Thread workerThread = new Thread(GeneratePassenger);
            workerThread.Start();
        }

        public void Close()
        {
            Monitor.Enter(_magicLock);
            IsOpen = false;
            Console.WriteLine($"Closing reception: {ID}");
        }

        public void Open()
        {
            if(Monitor.IsEntered(_magicLock)) Monitor.Exit(_magicLock);
            IsOpen = true;
            Console.WriteLine($"Opening reception: {ID}");
        }

        private void GeneratePassenger()
        {
            Random rng = new Random();

            while (true)
            {
                if (!IsOpen) Monitor.Wait(_magicLock);

                Passenger passenger = new Passenger(Passenger.GenerateName(), Guid.NewGuid());

                int numLuggage = rng.Next(0, 4);

                for (int i = 0; i < numLuggage; i++)
                {
                    passenger.AddLuggage(new Luggage(Guid.NewGuid(), DateTime.Now));
                }

                // Make reservation for a random flight for this passenger.
                passenger.Reservation = new Reservation(passenger, _flights[rng.Next(0, _flights.Length - 1)]);

                Console.WriteLine(passenger);

                // Sort the passengers luggage:
                foreach (Luggage luggage in passenger.GetLuggage())
                {
                    LuggageSorter.QueueLuggage(luggage);
                }


                Thread.Sleep(1500);
            }
        }

    }
}
