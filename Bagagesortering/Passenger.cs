using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Passenger
    {
        private readonly List<Luggage> _luggage = new List<Luggage>();

        public string Name { get; set; }
        public Guid ID { get; private set; }

        public Passenger(string name, Guid id)
        {
            Name = name;
            ID = id;
        }

        public void AddLuggage(Luggage luggage)
        {
            luggage.Owner = this;
            this._luggage.Add(luggage);
        }

        public List<Luggage> GetLuggage()
        {
            return this._luggage;
        }
    }
}
