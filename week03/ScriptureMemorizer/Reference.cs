public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
        : this(book, chapter, startVerse)
    {
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return _endVerse.HasValue ?
            $"{_book} {_chapter}:{_startVerse}-{_endVerse}" :
            $"{_book} {_chapter}:{_startVerse}";
    }

    public string GetReferenceId() => 
        _endVerse.HasValue ? 
        $"{_book}_{_chapter}_{_startVerse}_{_endVerse}" : 
        $"{_book}_{_chapter}_{_startVerse}";
}