using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Reservation
    {
        public Passenger Passenger { get; private set; }
        public Flight Flight { get; private set; }

        public Reservation(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            Flight = flight;

            this.Passenger.Reservation = this;
        }

    }
}
