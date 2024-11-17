namespace BookManagmentSystem.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }

        public DateTime PuplishedYear { get; set; }

        //For ADD and Update
        public List<int> GenresId { get; set; }
        public List<int> AuthorsId { get; set; }

        //For GET ALL
        public List<string>? Authors { get; set; }
        public List<string>? Genres { get; set; }
    }
}
