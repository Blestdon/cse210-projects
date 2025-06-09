using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video("Exploring the Grand Canyon", "John Smith", 420);
        video1.AddComment(new Comment("Alice", "This video is amazing!"));
        video1.AddComment(new Comment("Bob", "I've always wanted to go there."));
        video1.AddComment(new Comment("Carol", "Great cinematography!"));

        Video video2 = new Video("How to Bake Bread", "BakingWithEmma", 300);
        video2.AddComment(new Comment("David", "Tried this and it came out great!"));
        video2.AddComment(new Comment("Ella", "Can you do sourdough next?"));
        video2.AddComment(new Comment("Frank", "Loved the step-by-step guide."));

        Video video3 = new Video("Top 10 Coding Tips", "CodeMaster", 540);
        video3.AddComment(new Comment("Grace", "These tips really helped."));
        video3.AddComment(new Comment("Hank", "Tip #7 blew my mind!"));
        video3.AddComment(new Comment("Ivy", "Can you do a version for Python?"));

        Video video4 = new Video("Relaxing Piano Music", "CalmSounds", 600);
        video4.AddComment(new Comment("Jack", "Perfect for studying."));
        video4.AddComment(new Comment("Kara", "So peaceful."));
        video4.AddComment(new Comment("Liam", "My cat fell asleep listening to this."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display all video details and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
