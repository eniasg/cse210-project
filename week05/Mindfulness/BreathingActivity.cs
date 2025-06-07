class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through breathing in and out slowly.";
    }

    public override void Run()
    {
        StartActivity();
        int cycle = _duration / 6;
        for (int i = 0; i < cycle; i++)
        {
            ShowBreathing("Breathe in", 3);
            ShowBreathing("Breathe out", 3);
        }
        EndActivity();
    }

    private void ShowBreathing(string message, int seconds)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.Clear();
            Console.WriteLine($"{message} {new string('.', i)}");
            Thread.Sleep(seconds * 100 / 10);
        }
    }
}