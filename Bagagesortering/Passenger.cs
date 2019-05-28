using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesortering
{
    public class Passenger
    {
        private readonly List<Luggage> _luggage = new List<Luggage>();
        private static string[] _firstNames = File.ReadAllLines("top100firstnames.txt");
        private static string[] _lastNames = File.ReadAllLines("top100lastnames.txt");
        private static Random rng = new Random();

        public string Name { get; set; }
        public Guid ID { get; private set; }

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
            this._luggage.Add(luggage);
        }

        public List<Luggage> GetLuggage()
        {
            return this._luggage;
        }

        public static string GenerateName()
        {
            return $"{_firstNames[rng.Next(0, _firstNames.Length)]} {_lastNames[rng.Next(0, _lastNames.Length)]}";


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

            sb.AppendLine(this.Name);
            sb.AppendLine($"ID: {this.ID.ToString()}");
            sb.AppendLine($"Flight: {this.Reservation.Flight.Name}");
            sb.AppendLine($"Terminal: {this.Reservation.Flight.Terminal.ID}");

            foreach (Luggage luggage in _luggage)
            {
                sb.AppendLine($"Luggage: {luggage.ID}");
            }

            return sb.ToString();

        }
    }
}
