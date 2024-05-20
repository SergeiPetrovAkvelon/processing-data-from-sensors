using System;
using System.IO;
using Newtonsoft.Json;
using Processing_data.Classes;

string json = File.ReadAllText("data.json");
DataValue[] data = JsonConvert.DeserializeObject<DataValue[]>(json);

if (data == null)
{
    Console.WriteLine("Failed to deserialize the JSON data");
    return;
}
PrintingStatsService printingService = new PrintingStatsService();
StatsBucket statsBucket = new StatsBucket(printingService, 5);

foreach (DataValue dataValue in data)
{
    Coordinate coordinate = new Coordinate() { Latitude = dataValue.Latitude, Longitude = dataValue.Longitude };
    statsBucket.AddData(coordinate, dataValue.Value);
}

statsBucket.PrintStats();