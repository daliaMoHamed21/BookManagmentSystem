using BookManagmentSystem.DTOs;
using BookManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagmentSystem.Repos.GenreRepo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly ApplicationDbContext _context;
        public GenreRepo(ApplicationDbContext context)
        {
            _context = context;

        }
        public void AddGenre(GenreDTO genreDto)
        {
            var Genre = new Genre
            {
                Name = genreDto.Name,


            };
            _context.Add(Genre);
            _context.SaveChanges();
            
                
                ;
        }

        public void DeleteGenre(int id)
        {
            var genre =_context.Genres.SingleOrDefault(x => x.Id == id);
            if (genre != null) { 
                _context.Remove(genre);
            }

        }

        public IEnumerable<GenreDTO> GetAllGenres()
        {
            var Genre = _context.Genres.Include(b => b.Books)
                .Select(a => new GenreDTO
                {
                    Name = a.Name,
                    Books = a.Books.Select(b => b.Title).ToList()

                }).ToList();
            return Genre;     
        }

        public GenreDTO GetGenreById(int id)
        {
            var genre =_context.Genres.Include(g => g.Books).FirstOrDefault(g=>g.Id==id);
            return new GenreDTO
            {
                Name=genre.Name,
                Books=genre.Books.Select(g=>g.Title).ToList(),
            };
        }

        public void UpdateGenre(int id, GenreDTO genreDto)
        {
            var genre = _context.Genres.Include(g => g.Books).FirstOrDefault(g => g.Id == id);
            new Genre
            {
                Name = genre.Name,
               
            };
             _context.Update(genreDto);
            _context.SaveChanges();
        }
    }
}
