using Processing_data.Interfaces;

namespace Processing_data.Classes
{
    public class PrintingStatsService : IPrinter
    {
        public void Print(StatsBucket statsBucket)
        {
            foreach (KeyValuePair<Coordinate, Statistics> pair in statsBucket)
            {
                Console.WriteLine($"Coordinate: {pair.Key.Latitude}, {pair.Key.Longitude}. Data: {pair.Value.GetDataCount()} values.");
                Console.WriteLine($"Min: {pair.Value.MIN}");
                Console.WriteLine($"Max: {pair.Value.MAX}");
                Console.WriteLine($"AVG: {pair.Value.AVG}");
                Console.WriteLine($"STD: {pair.Value.STD}");
                Console.WriteLine();
            }
        }
    }
}