using Newtonsoft.Json;
using Processing_data;
using Processing_data.Classes;

string json = File.ReadAllText("data.json");
DataValue[] data = JsonConvert.DeserializeObject<DataValue[]>(json);

if (data == null)
{
    Console.WriteLine("Failed to deserialize the JSON data");
    return;
}

var query = from d in data
            group d by new Coordinate() { Latitude = Math.Round(d.Latitude, 2), Longitude = Math.Round(d.Longitude, 2) } into g
            select new { g.Key, Value = new Statistics(g.Select(x => x.Value).ToList()) };

// var query = data.GroupBy(x => new Coordinate() { Latitude = Math.Round(x.Latitude, 2), Longitude = Math.Round(x.Longitude, 2) })
//                 .Select(g => new { Key = g.Key, Value = new Statistics(g.Select(x => x.Value).ToList()) });


PrintingStatsService printingService = new PrintingStatsService();
StatsBucket statsBucket = new StatsBucket();
foreach (var item in query)
{
    statsBucket.Add(item.Key, item.Value);
}

PrintingStatsService.Print(statsBucket);