using BookManagmentSystem.DTOs;

namespace BookManagmentSystem.Repos.GenreRepo
{
    public interface IGenreRepo
    {
        IEnumerable<GenreDTO> GetAllGenres();
        GenreDTO GetGenreById(int id);
        void AddGenre(GenreDTO genreDto);
        void UpdateGenre(int id, GenreDTO genreDto);
        void DeleteGenre(int id);
    }
}
