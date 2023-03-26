using System;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}
class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("My thoughts on chefs", "John Doe", 600);
        Video video2 = new Video("Tik Toks that induce labor", "Jane Smith", 1180);
        Video video3 = new Video("How to cook a whopper at home", "Bob Johnson", 2000);
        Video video4 = new Video("When is it okay to jump off a bridge", "Thea Johnson", 10);

        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Thanks for sharing."));
        video2.AddComment(new Comment("Spencer", "Funny, but I wasn't pregnant so it didn't work"));
        video2.AddComment(new Comment("Aubrey", "This did the trick!"));
        video2.AddComment(new Comment("Charlie", "Nice job!"));
        video2.AddComment(new Comment("David", "Keep up the good work."));
        video3.AddComment(new Comment("Emily", "This was really helpful!"));
        video3.AddComment(new Comment("Frank", "I learned a lot from this."));
        video3.AddComment(new Comment("James", "Great video. But my mom is still a better cook"));
        video4.AddComment(new Comment("Stanley", "I don't know what I expected"));
        video4.AddComment(new Comment("Peter", "Obviously the answer was never"));

        List<Video> videos = new List<Video>() { video1, video2, video3, video4 };

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (in seconds): " + video.LengthInSeconds);
            Console.WriteLine("Number of comments: " + video.GetNumberOfComments());

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine("Comment by " + comment.Name + ": " + comment.Text);
            }

            Console.WriteLine();
        }
    }
}
