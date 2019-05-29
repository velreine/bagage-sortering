using System;
using System.IO;

namespace Bagagesortering
{
    public class Flight
    {
        private static readonly Random RNG = new Random();
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Terminal Terminal { get; set; }
        private static readonly string[] FlightFirstName = File.ReadAllLines("top100adjectives.txt");
        private static readonly string[] FlightLastName = File.ReadAllLines("animals.txt");

        public Flight(Terminal terminal, Guid id, string name)
        {
            Terminal = terminal;
            ID = id;
            Name = name;
        }

        public static string GenerateName()
        {
            return
                $"{FlightFirstName[RNG.Next(0, FlightFirstName.Length)]} {FlightLastName[RNG.Next(0, FlightLastName.Length)]}";
        }

    }
}
