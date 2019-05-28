using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Reception
    {
        public Guid ID { get; set; }

        public Reception(Guid id)
        {
            ID = id;    
        }

        public Reservation MakeReservation(Passenger passenger, Flight flight)
        {
            return new Reservation(passenger, flight);
        }


    }
}
