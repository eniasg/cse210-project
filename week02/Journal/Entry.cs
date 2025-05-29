using System;

public class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {Date.ToString("MM/dd/yyyy HH:mm")}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }
}