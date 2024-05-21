namespace Processing_data.Classes
{
    /// <summary>
    /// Represents a custom equality comparer for the Coordinate class
    /// </summary>
    public class CustomEqualityComparer : IEqualityComparer<Coordinate>
    {
        /// <summary>
        /// Rounds the value to two decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double Round(double value)
        {
            return Math.Round(value, 2);
        }

        /// <summary>
        /// Compares two coordinates for equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Coordinate x, Coordinate y)
        {
            return Round(x.Latitude) == Round(y.Latitude) && Round(x.Longitude) == Round(y.Longitude);
        }

        /// <summary>
        /// Returns the hash code for the coordinate
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Coordinate obj)
        {
            return Round(obj.Latitude).GetHashCode() ^ Round(obj.Longitude).GetHashCode();
        }
    }
}