using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("✅ Entry added successfully!");
    }

    public void DisplayAll()
    {
        Console.WriteLine("\n📖 Your Journal Entries:");
        foreach (var entry in _entries)
        {
            Console.WriteLine($"🗓 Date: {entry.Date}");
            Console.WriteLine($"📝 Prompt: {entry.PromptText}");
            Console.WriteLine($"✍️ Entry: {entry.EntryText}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Date,Prompt,Entry");
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToCsv());
            }
        }
        Console.WriteLine($"💾 Journal saved to '{fileName}' successfully!");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("⚠️ File not found.");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            bool firstLine = true;
            while ((line = reader.ReadLine()) != null)
            {
                if (firstLine) { firstLine = false; continue; }

                string[] parts = ParseCsvLine(line);
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
        Console.WriteLine($"📂 Journal loaded from '{fileName}' successfully!");
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    current += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }

        fields.Add(current);
        return fields.ToArray();
    }
}
