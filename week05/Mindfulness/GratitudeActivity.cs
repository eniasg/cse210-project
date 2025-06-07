class GratitudeActivity : Activity
{
    public GratitudeActivity()
    {
        _name = "Gratitude";
        _description = "This activity will help you express gratitude and recognize blessings in your life.";
    }

    public override void Run()
    {
        StartActivity();
        Console.WriteLine("Think of specific things you are thankful for today:");
        ShowCountdown(5);
        List<string> list = new();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                list.Add(input);
        }
        Console.WriteLine($"You expressed gratitude for {list.Count} things.");
        EndActivity();
    }
}