using System;
using System.Collections.Generic;
using System.Threading;

namespace Bagagesortering
{
    public static class LuggageSorter
    {

        public static object ConveyBeltLock = new object();
        private static readonly Queue<Luggage> ConveyerBelt = new Queue<Luggage>(200);
        //private static Terminal[] _terminals;
        //private static Reception[] _receptions;

        /*public LuggageSorter(Terminal[] terminals, Reception[] receptions)
        {
            _terminals = terminals;
            _receptions = receptions;
        }*/

        private static bool Sort(Luggage luggage)
        {
            Console.WriteLine($"Trying to sort {luggage.Owner.Name}'s {luggage.ID}, putting it in Terminal: {luggage.Owner.Reservation.Flight.Terminal.ID}");
            return luggage.Owner.Reservation.Flight.Terminal.AddLuggage(luggage);
            //return false;
        }

        public static void Sort()
        {
            while (true)
            {
                lock (ConveyBeltLock)
                {
                    if (ConveyerBelt.Count == 0)
                    {
                        //Console.WriteLine("Sorting thread now waiting for a pulse on _conveyerBelt!");
                        // Wait for things to be put on the convey belt.
                        Monitor.Wait(ConveyBeltLock);
                    }
                    else
                    {
                        Sort(ConveyerBelt.Dequeue());
                    }
                }
            }
        }

        public static void QueueLuggage(Luggage luggage)
        {
            lock (ConveyBeltLock)
            {
                ConveyerBelt.Enqueue(luggage);

                Monitor.PulseAll(ConveyBeltLock);
            }

        }
    }
}
