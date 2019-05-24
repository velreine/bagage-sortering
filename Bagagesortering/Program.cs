using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    class Program
    {
        static void Main(string[] args)
        {


            var passenger = new Passenger("Nicky Hansen", Guid.NewGuid());

            for (int i = 0; i < 3; i++)
            {
                passenger.AddLuggage(new Luggage(Guid.NewGuid(), DateTime.Now));
            }





        }
    }
}
