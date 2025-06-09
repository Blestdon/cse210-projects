using System;

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return StartVerse == EndVerse
            ? $"{Book} {Chapter}:{StartVerse}"
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }

    public static Reference Parse(string input)
    {
        // Example: "Proverbs 3:5-6"
        var parts = input.Split(' ');
        string book = parts[0];
        var chapterAndVerse = parts[1].Split(':');
        int chapter = int.Parse(chapterAndVerse[0]);

        if (chapterAndVerse[1].Contains('-'))
        {
            var verseRange = chapterAndVerse[1].Split('-');
            return new Reference(book, chapter, int.Parse(verseRange[0]), int.Parse(verseRange[1]));
        }
        else
        {
            return new Reference(book, chapter, int.Parse(chapterAndVerse[1]));
        }
    }
}
