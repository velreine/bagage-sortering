using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bagagesortering
{
    public class Passenger
    {
        private readonly List<Luggage> _luggage = new List<Luggage>();
        private static string[] _firstNames = File.ReadAllLines("top100firstnames.txt");
        private static string[] _lastNames = File.ReadAllLines("top100lastnames.txt");
        private static readonly Random RNG = new Random();

        public string Name { get; set; }
        public Guid ID { get; }

        public Reservation Reservation { get; set; }

        public Passenger(string name, Guid id)
        {

            if (_firstNames == null)
            {
                _firstNames = LoadFirstNames();
            }

            if (_lastNames == null)
            {
                _lastNames = LoadLastNames();
            }



            Name = name;
            ID = id;
        }

        public void AddLuggage(Luggage luggage)
        {
            luggage.Owner = this;
            _luggage.Add(luggage);
        }

        public List<Luggage> GetLuggage()
        {
            return _luggage;
        }

        public static string GenerateName()
        {
            return $"{_firstNames[RNG.Next(0, _firstNames.Length)]} {_lastNames[RNG.Next(0, _lastNames.Length)]}";


        }


        private string[] LoadFirstNames()
        {
            return File.ReadAllLines("top100firstnames.txt");
        }

        private string[] LoadLastNames()
        {
            return File.ReadAllLines("top100lastnames.txt");
        }


        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine($"ID: {ID.ToString()}");
            sb.AppendLine($"Flight: {Reservation.Flight.Name}");
            sb.AppendLine($"Terminal: {Reservation.Flight.Terminal.ID}");

            foreach (Luggage luggage in _luggage)
            {
                sb.AppendLine($"Luggage: {luggage.ID}");
            }

            return sb.ToString();

        }
    }
}

