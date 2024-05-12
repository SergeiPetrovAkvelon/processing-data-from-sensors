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
        private double _max;
        private double _min;
        private double _avg;
        private double _std;
        public double MAX
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
        public double MIN
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;

            }
        }
        public double AVG
        {
            get
            {
                return _avg;
            }
            set
            {
                _avg = value;
            }
        }
        public double STD
        {
            get
            {
                return _std;
            }
            set
            {
                _std = value;
            }
        }

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
            double sum = 0;
            double sum2 = 0;

            if (data.Count > 0)
            {
                _max = data[0];
                _min = data[0];
            }

            foreach (var item in data)
            {
                if (item > _max)
                {
                    _max = item;
                }

                if (item < _min)
                {
                    _min = item;
                }

                sum += item;
                sum2 += item * item;
            }

            _avg = sum / data.Count;

            _std = Math.Sqrt(sum2 / data.Count - _avg * _avg);
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
