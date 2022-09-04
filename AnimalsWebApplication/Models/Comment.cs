namespace AnimalsWebApplication.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public string? CommentText { get; set; }
        public Animal? Animal { get; set; }

    }
}
