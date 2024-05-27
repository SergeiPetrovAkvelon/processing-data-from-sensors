namespace Processing_data.Classes
{
    /// <summary>
    /// Represents statistics for a set of data
    /// </summary>
    public class Statistics
    {
        public double Max { get; private set; }
        public double Min { get; private set; }
        public double Avg { get; private set; }
        public double Std { get; private set; }

        private readonly List<double> data;

        public Statistics(List<double> data)
        {
            this.data = new List<double>(data);
            Calculate();
        }

        /// <summary>
        /// Adds a data value to the statistics
        /// </summary>
        /// <param name="data"></param>
        public void AddData(double data)
        {
            this.data.Add(data);
            Calculate();
        }

        /// <summary>
        /// Calculates the statistics
        /// </summary>
        private void Calculate()
        {
            if (data.Count == 0)
            {
                Max = 0;
                Min = 0;
                Avg = 0;
                Std = 0;
                return;
            }

            Max = data.Max();
            Min = data.Min();
            Avg = data.Average();
            Std = Math.Sqrt(data.Average(v => Math.Pow(v - Avg, 2)));
        }

        /// <summary>
        /// Returns the number of data values
        /// </summary>
        /// <returns></returns>
        public int GetDataCount()
        {
            return data.Count;
        }
    }
}