using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Deep Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    public override void Run()
    {
        Start();
        
        int cycles = (int)Math.Ceiling((double)Duration / 10);
        if (cycles == 0) cycles = 1;
        
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            
            Console.Write("Breathe out... ");
            ShowCountdown(6);
        }
        
        End();
    }
}