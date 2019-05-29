using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Reception
    {
        public Guid ID { get; set; }
        public bool Open { get; private set; } = true;

        private readonly Thread _workerThread;

        public Reception(Guid id, Thread workerThread)
        {
            ID = id;
            this._workerThread = workerThread;
            _workerThread.Start();
        }

        public Reservation MakeReservation(Passenger passenger, Flight flight)
        {
            return new Reservation(passenger, flight);
        }

        public void Close()
        {
            Open = false;
            _workerThread.Abort();
        }

    }
}
