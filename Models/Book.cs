namespace BookManagmentSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PuplishedYear { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
