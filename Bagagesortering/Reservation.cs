using System;

namespace Bagagesortering
{
    public class Reservation
    {
        public Passenger Passenger { get; }
        public Flight Flight { get; }

        public Reservation(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            Flight = flight;

            if(flight == null)
                Console.WriteLine("Reservation created with NULL flight??");

            Passenger.Reservation = this;
        }

    }
}
