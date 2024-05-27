using Processing_data.Classes;

namespace Processing_data
{
    public class PrintingStatsService
    {
        public static void Print(StatsBucket statsBucket)
        {
            foreach (KeyValuePair<Coordinate, Statistics> pair in statsBucket)
            {
                Console.WriteLine($"Coordinate: {pair.Key.Latitude}, {pair.Key.Longitude}. Data: {pair.Value.GetDataCount()} values.");
                Console.WriteLine($"Min: {pair.Value.Min}");
                Console.WriteLine($"Max: {pair.Value.Max}");
                Console.WriteLine($"Avg: {pair.Value.Avg}");
                Console.WriteLine($"Std: {pair.Value.Std}");
                Console.WriteLine();
            }
        }
    }
}