using System;
using System.Collections.Generic;

// Class representing a Comment
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
    
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Class representing a YouTube Video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }
    
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    
    public int GetCommentCount()
    {
        return Comments.Count;
    }
    
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Creating video instances
        Video video1 = new Video("Introduction to C#", "CodeAcademy", 600);
        Video video2 = new Video("Advanced OOP Concepts", "TechGuru", 1200);
        Video video3 = new Video("Understanding Data Structures", "AlgoMaster", 900);
        
        // Adding comments to video1
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Clear and concise."));
        
        // Adding comments to video2
        video2.AddComment(new Comment("Dave", "This was a bit challenging but worth it!"));
        video2.AddComment(new Comment("Eve", "Awesome explanations."));
        video2.AddComment(new Comment("Frank", "Thanks for the detailed breakdown!"));
        
        // Adding comments to video3
        video3.AddComment(new Comment("Grace", "Data structures made easy!"));
        video3.AddComment(new Comment("Hank", "Loved the examples."));
        video3.AddComment(new Comment("Ivy", "Great teaching style!"));
        
        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };
        
        // Displaying video details
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
