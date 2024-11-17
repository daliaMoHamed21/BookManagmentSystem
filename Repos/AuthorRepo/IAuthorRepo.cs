using BookManagmentSystem.DTOs;

namespace BookManagmentSystem.Repos.AuthorRepo
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int id);
        void AddAuthor(AuthorDTO authorDto);
        void UpdateAuthor(int id, AuthorDTO authorDto);
        void DeleteAuthor(int id);
    }
}
