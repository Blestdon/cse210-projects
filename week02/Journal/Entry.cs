using System;

class Entry
{
    public string Date { get; private set; }
    public string PromptText { get; private set; }
    public string EntryText { get; private set; }

    // For new entry
    public Entry(string prompt, string entryText)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        PromptText = prompt;
        EntryText = entryText;
    }

    // For loading from file
    public Entry(string date, string prompt, string entryText)
    {
        Date = date;
        PromptText = prompt;
        EntryText = entryText;
    }

    public override string ToString()
    {
        return $"{Date}|{PromptText}|{EntryText}";
    }

    public string ToCsv()
    {
        return $"\"{Date}\",\"{PromptText.Replace("\"", "\"\"")}\",\"{EntryText.Replace("\"", "\"\"")}\"";
    }
}
