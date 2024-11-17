namespace BookManagmentSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
