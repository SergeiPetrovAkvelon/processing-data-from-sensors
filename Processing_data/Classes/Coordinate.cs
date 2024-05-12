using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processing_data.Classes
{
    /// <summary>
    /// Represents a geographical coordinate
    /// </summary>
    public struct Coordinate: IEquatable<Coordinate>, IComparable<Coordinate>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        public bool Equals(Coordinate other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }

        public int CompareTo(Coordinate other)
        {
            if (Latitude == other.Latitude)
            {
                return Longitude.CompareTo(other.Longitude);
            }
            return Latitude.CompareTo(other.Latitude);
        }
    }
}
