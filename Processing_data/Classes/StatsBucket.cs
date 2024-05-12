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

        /// <summary>
        /// Prints the statistics for each coordinate in the bucket
        /// </summary>
        public void PrintStats()
        {
            foreach (KeyValuePair<Coordinate, Statistics> pair in this)
            {
                Console.WriteLine($"Coordinate: {pair.Key.Latitude}, {pair.Key.Longitude}. Data: {pair.Value.GetDataCount()} values.");
                if (pair.Value.GetDataCount() < 100)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Data is not enough to calculate the minimum value");
                    Console.ResetColor();
                    continue;
                }
                Console.WriteLine($"Min: {pair.Value.MIN}");
                Console.WriteLine($"Max: {pair.Value.MAX}");
                Console.WriteLine($"AVG: {pair.Value.AVG}");
                Console.WriteLine($"STD: {pair.Value.STD}");
                Console.WriteLine();
            }
        }
    }
}