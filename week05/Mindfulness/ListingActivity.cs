class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you helped this week?",
        "What are some things you're grateful for?"
    };
    private List<string> _usedPrompts = new();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by listing them.";
    }

    public override void Run()
    {
        StartActivity();
        string prompt = GetUnusedPrompt(_prompts, ref _usedPrompts);
        Console.WriteLine(prompt);
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        List<string> responses = new();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                responses.Add(input);
        }

        Console.WriteLine($"You listed {responses.Count} items.");
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