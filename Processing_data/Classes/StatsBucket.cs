namespace Processing_data.Classes
{
    /// <summary>
    /// Represents a collection of statistics for a set of data
    /// </summary>
    public class StatsBucket : Dictionary<Coordinate, Statistics>
    {
        /// <summary>
        /// Adds a data value to the statistics bucket
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="data"></param>
        public void AddData(Coordinate coordinate, double data)
        {
            if (!ContainsKey(coordinate))
            {
                Add(coordinate, new Statistics(new List<double> { data }));
            }
            else
            {
                this[coordinate].AddData(data);
            }
        }

        public StatsBucket(int capacity) : base(capacity, new CustomEqualityComparer())
        {
        }
        public StatsBucket() : base(new CustomEqualityComparer())
        {
        }
    }
}