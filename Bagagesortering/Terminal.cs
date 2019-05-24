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

        public Terminal(Guid id)
        {
            ID = id;
        }
    }
}
