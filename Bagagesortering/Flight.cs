using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Flight
    {
        public Guid ID { get; set; }
        public Terminal Terminal { get; set; }

        public Flight(Terminal terminal, Guid id)
        {
            Terminal = terminal;
            ID = id;
        }
    }
}
