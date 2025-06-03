using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();
        
        var video1 = new Video("C# Tutorial", "Programming Guru", 600);
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "Helped me understand classes better"));
        video1.AddComment(new Comment("Charlie", "When's the next part coming?"));
        
        var video2 = new Video("OOP Principles", "Code Master", 450);
        video2.AddComment(new Comment("Dave", "Abstraction explained perfectly"));
        video2.AddComment(new Comment("Eve", "Would love more examples"));
        video2.AddComment(new Comment("Frank", "Perfect for my exam prep"));
        video2.AddComment(new Comment("Grace", "Replayed this 3 times!"));
        
        var video3 = new Video("ASP.NET Core", "Web Wizard", 1200);
        video3.AddComment(new Comment("Heidi", "Life-saving tutorial"));
        video3.AddComment(new Comment("Ivan", "Clear and practical"));
        video3.AddComment(new Comment("Judy", "Solved my dependency injection issues"));
        
        videos.AddRange(new[] { video1, video2, video3 });
        
        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            
            Console.WriteLine("\n====================\n");
        }
    }
}