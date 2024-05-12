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

StatsBucket statsBucket = new StatsBucket();

foreach (DataValue dataValue in data)
{
    Coordinate coordinate = new Coordinate(Math.Round(dataValue.Latitude, 2), Math.Round(dataValue.Longitude, 2));
    statsBucket.AddData(coordinate, dataValue.Value);
}

statsBucket.PrintStats();


