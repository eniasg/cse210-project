class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel when it was complete?",
        "What made this time different from others?"
    };

    private List<string> _usedPrompts = new();
    private List<string> _usedQuestions = new();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine(GetUnusedPrompt(_prompts, ref _usedPrompts));
        Thread.Sleep(3000);

        int secondsLeft = _duration;
        while (secondsLeft > 5)
        {
            string question = GetUnusedPrompt(_questions, ref _usedQuestions);
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
            secondsLeft -= 5;
        }

        EndActivity();
    }

    private string GetUnusedPrompt(List<string> source, ref List<string> used)
    {
        if (used.Count == source.Count)
            used.Clear();
        var remaining = source.Except(used).ToList();
        string item = remaining[new Random().Next(remaining.Count)];
        used.Add(item);
        return item;
    }
}