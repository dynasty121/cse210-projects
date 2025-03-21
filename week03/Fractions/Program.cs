using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }

            Console.Write("\nPress Enter to hide more words or type 'quit' to exit: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random unhidden words
        }
    }
}

// Represents the reference (e.g., "John 3:16" or "Proverbs 3:5-6")
class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verse;
        this.verseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (verseStart == verseEnd)
            return $"{book} {chapter}:{verseStart}";
        else
            return $"{book} {chapter}:{verseStart}-{verseEnd}";
    }
}

// Represents a single word in the scripture
class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string GetDisplayText()
    {
        return hidden ? new string('_', text.Length) : text;
    }
}

// Represents the scripture with reference and words
class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (var word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        var unhiddenWords = words.Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Min(count, unhiddenWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }
}

// Loads scriptures from a file and selects one randomly
class ScriptureLibrary
{
    private List<Scripture> scriptures = new List<Scripture>();
    private Random random = new Random();

    public ScriptureLibrary(string filename)
    {
        LoadFromFile(filename);
    }

    private void LoadFromFile(string filename)
    {
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            var refParts = parts[0].Split(' ');
            var book = refParts[0];
            var chapterAndVerse = refParts[1].Split(':');
            int chapter = int.Parse(chapterAndVerse[0]);
            var verseParts = chapterAndVerse[1].Split('-');

            Reference reference;
            if (verseParts.Length == 1)
                reference = new Reference(book, chapter, int.Parse(verseParts[0]));
            else
                reference = new Reference(book, chapter, int.Parse(verseParts[0]), int.Parse(verseParts[1]));

            scriptures.Add(new Scripture(reference, parts[1]));
        }
    }

    public Scripture GetRandomScripture()
    {
        return scriptures[random.Next(scriptures.Count)];
    }
}