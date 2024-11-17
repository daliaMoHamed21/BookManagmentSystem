using BookManagmentSystem.DTOs;
using BookManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagmentSystem.Repos.AuthorRepo
{

    
    
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDTO authorDto)
        {
            var author = new Author
                {
                   Name = authorDto.Name,
                   EmailAddress = authorDto.EmailAddress,
                   PhoneNumber = authorDto.PhoneNumber,  
                };
            _context.Add(author);
            _context.SaveChanges();
            
        }

        public void DeleteAuthor(int id)
        {
            var author =_context.Authors.FirstOrDefault(x => x.Id == id);
            if (author != null) { 
                _context.Authors.Remove(author);
            }
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            var authors = _context.Authors
                .Include(x => x.Books)
                .Select(a=>new AuthorDTO
                {
                    Name = a.Name, 
                    EmailAddress = a.EmailAddress,
                    PhoneNumber = a.PhoneNumber,
                    Books=a.Books.Select(b=>b.Title).ToList()

                });
            return authors;
        }

        public AuthorDTO GetAuthorById(int id)
        {
           var author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if(author == null)
            {
                return null;
            }
             return new AuthorDTO
            {
                Name= author.Name,
                PhoneNumber= author.PhoneNumber,
                EmailAddress = author.EmailAddress,
                Books = author.Books?.Select(b => b.Title).ToList() ?? new List<string>()

             };



        }

        public void UpdateAuthor(int id, AuthorDTO authorDto)
        {
            var author =_context.Authors.Include(b=>b.Books).FirstOrDefault(x => x.Id == id);
            author.PhoneNumber = authorDto.PhoneNumber;
            author.EmailAddress = authorDto.EmailAddress;
            author.Name = authorDto.Name;

            _context.Authors.Update(author);
            _context.SaveChanges();
            

        }
    }
}
