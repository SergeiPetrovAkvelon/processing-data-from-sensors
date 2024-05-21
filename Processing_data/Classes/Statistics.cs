using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processing_data.Classes
{
    /// <summary>
    /// Represents statistics for a set of data
    /// </summary>
    public class Statistics
    {
        public double MAX { get; set; }
        public double MIN { get; set; }
        public double AVG { get; set; }

        public double STD { get; set; }

        private List<double> data;

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
                MAX = 0;
                MIN = 0;
                AVG = 0;
                STD = 0;
                return;
            }

            MAX = data.Max();
            MIN = data.Min();
            AVG = data.Average();
            STD = Math.Sqrt(data.Average(v => Math.Pow(v - AVG, 2)));
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
