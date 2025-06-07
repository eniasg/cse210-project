class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write("|/-\\"[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        }
    }

    public abstract void Run();
}