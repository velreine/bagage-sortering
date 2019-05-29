using System;
using System.Threading;

namespace Bagagesortering
{
    internal class Program
    {
        private const int ReceptionCount = 1;
        private static readonly Reception[] Receptions = new Reception[ReceptionCount];
        private const int FlightCount = 8;
        private static readonly Flight[] Flights = new Flight[FlightCount];
        private static readonly Terminal[] Terminals = new Terminal[FlightCount]; // 1 terminal per flight.

        private static void Main()
        {
            // Generates flights, terminals and receptions.
            InitializeStaticData();

            // Create our Sorting Thread.
            Thread sortingThread = new Thread(LuggageSorter.Sort)
            {
                Name = "thread_sortingThread"
            };

            // Start the sorting thread.
            Console.WriteLine("Starting sorting thread!");
            sortingThread.Start();

            // Block Main-thread from exiting without user interaction.
            Console.ReadLine();
        }

        private static void InitializeStaticData()
        {
            Console.WriteLine("InitializeStaticData() running.");

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

            // Create some receptions.
            for (int i = 0; i < Receptions.Length; i++)
            {
                Receptions[i] = new Reception(Guid.NewGuid(), Flights);

                Thread.Sleep(2000);
                Receptions[i].Close();
                Thread.Sleep(500);
                Receptions[i].Open();

            }

            Console.WriteLine("InitializeStaticData() done!");
        }

    }
}
