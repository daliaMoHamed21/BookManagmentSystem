using BookManagmentSystem.DTOs;

namespace BookManagmentSystem.Repos.BookRepo
{
    public interface IBookRepo
    {
        IEnumerable<BookDTO>GetAllBooks();

        BookDTO GetBookById(int id);
        void AddBook(BookDTO bookDto);
        void UpdateBook(BookDTO bookDto, int id);

        void DeleteBook(int id);

    }
}
