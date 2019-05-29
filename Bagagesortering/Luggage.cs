using System;

namespace Bagagesortering
{
    public class Luggage
    {

        public Passenger Owner { get; set; }

        public Guid ID { get; }
        public DateTime Retrieved { get; }
        public DateTime Sorted { get; set; }

        public Luggage(Guid id, DateTime timeRetrieved)
        {
            ID = id;
            Retrieved = timeRetrieved;
   
        }


    }
}
