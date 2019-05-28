using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class LuggageSorter
    {

        public static object sorterLock = new object();
        private static Queue<Luggage> _conveyerBelt = new Queue<Luggage>(200);
        private static Terminal[] _terminals;
        private static Reception[] _receptions;

        public LuggageSorter(Terminal[] terminals, Reception[] receptions)
        {
            _terminals = terminals;
            _receptions = receptions;
        }

        public static bool Sort(Luggage luggage)
        {
            Console.WriteLine($"Trying to sort {luggage.Owner.Name}'s {luggage.ID}, i want to put it in Terminal: {luggage.Owner.Reservation.Flight.Terminal.ID}");
            return luggage.Owner.Reservation.Flight.Terminal.AddLuggage(luggage);
            //return false;
        }

        public static void Sort()
        {
            while (true)
            {
                lock (sorterLock)
                {
                    if (_conveyerBelt.Count == 0)
                    {
                        Console.WriteLine("Sorting thread now waiting for a pulse on _conveyerBelt!");
                        Monitor.Wait(sorterLock);
                    }
                    else
                    {
                        Sort(_conveyerBelt.Dequeue());
                    }
                }
            }
        }

        public static void QueueLuggage(Luggage luggage)
        {
            _conveyerBelt.Enqueue(luggage);
        }
        


    }
}
