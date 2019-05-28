using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Terminal
    {
        public Guid ID { get; set; }
        private Luggage[] _luggage = new Luggage[100];

        public Terminal(Guid id)
        {
            ID = id;
        }

        public bool AddLuggage(Luggage luggage)
        {
            // Return false if we couldn't add the luggage to the array.
            bool result = false;

            for (int i = 0; i < _luggage.Length; i++)
            {
                // If there is no reference to luggage at the current index add the luggage.
                if (_luggage[i] == null)
                {
                    _luggage[i] = luggage;
                    result = true;
                    // Then break the for loop also.
                    break;
                }
            }

            return result;
        }


    }
}
