public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word.Trim()))
                     .ToList();
    }

    public void HideRandomWords(int count, bool prioritizeLong = false)
    {
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        if (!visibleWords.Any()) return;
        
        if (prioritizeLong)
        {
            // Prioritize longer words
            visibleWords.Sort((a, b) => 
                b.GetRawText().Length.CompareTo(a.GetRawText().Length));
        }

        for (int i = 0; i < Math.Min(count, visibleWords.Count); i++)
        {
            int index = prioritizeLong ? 
                i :  // Take from top of sorted list
                _rand.Next(visibleWords.Count);  // Random selection
                
            visibleWords[index].Hide();
        }
    }

    public void ApplyHints()
    {
        foreach (var word in _words.Where(w => w.IsHidden()))
        {
            word.ShowHint();
        }
    }

    public bool IsCompletelyHidden() => _words.All(word => word.IsHidden());

    public float GetCompletionPercentage()
    {
        int hiddenCount = _words.Count(word => word.IsHidden());
        return (float)hiddenCount / _words.Count;
    }

    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string text = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{reference}\n\n{text}";
    }

    public string GetReferenceId() => _reference.GetReferenceId();
}