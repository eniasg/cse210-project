using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n\n{scriptureText}";
    }
    public void HideRandomWords(int count)
    {
        // Get only the words that aren't already hidden
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();

        // If there are fewer visible words than requested, adjust the count
        count = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < count; i++)
        {
            if (visibleWords.Count == 0) break;

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove to avoid hiding the same word twice
        }
    }
}