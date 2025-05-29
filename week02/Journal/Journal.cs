using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> Entries { get; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(Entries, options);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);
        var loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);
        Entries.Clear();
        Entries.AddRange(loadedEntries);
    }
}