using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos list
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Learn C# in 30 Days", "Programming with Mosh", 1845);
        video1.AddComment(new Comment("@codeNewbie", "This helped me pass CSE 210!"));
        video1.AddComment(new Comment("@promise_e", "Abstraction finally makes sense."));
        video1.AddComment(new Comment("@devLife", "Great explanation at 12:34"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("BYU-I Campus Tour 2026", "BYU-Idaho", 720);
        video2.AddComment(new Comment("@futureStudent", "I want to go here!"));
        video2.AddComment(new Comment("@alumni2024", "Memories! Rexburg is cold but awesome."));
        video2.AddComment(new Comment("@visitor", "Beautiful campus"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 5 VS Code Extensions", "Tech Simplified", 950);
        video3.AddComment(new Comment("@coderGirl", "C# Dev Kit is a lifesaver"));
        video3.AddComment(new Comment("@promise_e", "Adding these right now"));
        video3.AddComment(new Comment("@johnDoe", "You missed Prettier"));
        video3.AddComment(new Comment("@sam", "Thanks for the tips!"));
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}