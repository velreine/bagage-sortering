using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Flight
    {
        private static Random rng = new Random();
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Terminal Terminal { get; set; }
        private static string[] _flightFirstName = File.ReadAllLines("top100adjectives.txt");
        private static string[] _flightLastName = File.ReadAllLines("animals.txt");

        public Flight(Terminal terminal, Guid id, string name)
        {
            Terminal = terminal;
            ID = id;
            this.Name = name;
        }

        public static string GenerateName()
        {
            return
                $"{_flightFirstName[rng.Next(0, _flightFirstName.Length)]} {_flightLastName[rng.Next(0, _flightLastName.Length)]}";
        }

    }
}
