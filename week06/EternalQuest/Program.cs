using System;

// Creativity and Exceeding Requirements:
// 1. Negative Goals - track bad habits that deduct points
// 2. Progress Goals - track incremental progress toward large goals
// 3. Comprehensive save/load system for all goal types

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}