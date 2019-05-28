using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesortering
{
    class Program
    {

        private static readonly Passenger[] Passengers = new Passenger[10];
        private static readonly Reception[] Receptions = new Reception[3];


        private const int FLIGHT_COUNT = 4;

        private static readonly Flight[] Flights = new Flight[FLIGHT_COUNT];
        private static readonly Terminal[] Terminals = new Terminal[FLIGHT_COUNT]; // 1 terminal per flight.

        static void Main(string[] args)
        {

            Initialize();


            Thread sortingThread = new Thread(LuggageSorter.Sort)
            {
                Name = "thread_sortingThread"
            };

            sortingThread.Start();




            foreach (Passenger passenger in Passengers)
            {
                //Console.WriteLine($"Passenger: {passenger.Name}");
                //Console.WriteLine($"ID: {passenger.ID}");
                //Console.WriteLine($"Flight: {passenger.Reservation.Flight.Name}");
                //Console.WriteLine($"Terminal: {passenger.Reservation.Flight.Terminal.ID}");
                // Sort all the passengers luggage.

                Console.WriteLine(passenger);

                foreach (Luggage luggage in passenger.GetLuggage())
                {
                    lock (LuggageSorter.sorterLock)
                    {
                        LuggageSorter.QueueLuggage(luggage);

                        Monitor.PulseAll(LuggageSorter.sorterLock);
                    }
                    //LuggageSorter.Sort(luggage);

                }

                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("");
            }

            Console.ReadLine();



        }


        static void Initialize()
        {
            Random rng = new Random();

            // Create some receptions.
            for (int i = 0; i < Receptions.Length; i++)
            {
                Receptions[i] = new Reception(Guid.NewGuid());
            }

            // Create some terminals.
            for (int i = 0; i < Terminals.Length; i++)
            {
                Terminals[i] = new Terminal(Guid.NewGuid());
            }

            // Create some flights and assign them the created terminals.
            for (int i = 0; i < Flights.Length; i++)
            {
                Flights[i] = new Flight(Terminals[i], Guid.NewGuid(), Flight.GenerateName());
            }

            // Create some passengers.
            for (int i = 0; i < Passengers.Length; i++)
            {
                Passengers[i] = new Passenger(Passenger.GenerateName(), Guid.NewGuid());

                // Make a reservation for a random flight.
                Passengers[i].Reservation = new Reservation(Passengers[i], Flights[rng.Next(0, Flights.Length-1)]);

                // TODO: Debug every passenger gets 2 luggage.
                for (int j = 0; j < 2; j++)
                {
                    Passengers[i].AddLuggage(new Luggage(Guid.NewGuid(), DateTime.Now));
                }

            }

        }

    }
}
