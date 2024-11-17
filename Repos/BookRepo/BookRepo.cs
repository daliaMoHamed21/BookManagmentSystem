using BookManagmentSystem.DTOs;
using BookManagmentSystem.Models;
using BookManagmentSystem.Repos.BookRepo;
using Microsoft.EntityFrameworkCore;

namespace BookManagmentSystem.Repos.Book
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext _context;
        public BookRepo(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public void AddBook(BookDTO bookDto)
        {

            var Book = new Models.Book
            {
                Title = bookDto.Title,
                PuplishedYear=bookDto.PuplishedYear,
                Authors=_context.Authors.Where(a=>bookDto.AuthorsId.Contains(a.Id)).ToList(),
                Genres =_context.Genres.Where(g=>bookDto.GenresId.Contains(g.Id)).ToList(),




                //bookDto.Genres.Select(new Genre)

            };
            _context.Books.Add(Book);
            _context.SaveChanges();
           
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(a => a.Id == id);
            _context.Remove(book);
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var Book = _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Select(b => new BookDTO
                {
                    Title = b.Title,
                    PuplishedYear = b.PuplishedYear,
                    Authors =b.Authors.Select(a=>a.Name).ToList(),
                    Genres=b.Genres.Select(a=>a.Name).ToList()  


                }).ToList();
            return Book;
           

        }

        public BookDTO GetBookById(int id)
        {
            var Book = _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(b=>b.Id==id);

            var b = new BookDTO
            {
                Title = Book.Title,
                PuplishedYear = Book.PuplishedYear,
                Authors = Book.Authors.Select(a => a.Name).ToList(),
                Genres = Book.Genres.Select(a => a.Name).ToList()


            };
            return b;
        }

        public void UpdateBook(BookDTO bookDto, int id)
        {
            var book = _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.Id == id);

            book.Title = bookDto.Title;
            book.PuplishedYear = bookDto.PuplishedYear;
            book.Authors = _context.Authors.Where(a => bookDto.AuthorsId.Contains(a.Id)).ToList();
            book.Genres = _context.Genres.Where(g => bookDto.GenresId.Contains(g.Id)).ToList();

            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
