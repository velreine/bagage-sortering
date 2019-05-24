using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Luggage
    {

        public Passenger Owner { get; set; }

        public Guid ID { get; private set; }
        public DateTime Retrieved { get; private set; }
        public DateTime Sorted { get; set; }

        public Luggage(Guid id, DateTime timeRetrieved)
        {
            ID = id;
            Retrieved = timeRetrieved;
   
        }


    }
}
