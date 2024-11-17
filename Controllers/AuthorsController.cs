using BookManagmentSystem.DTOs;
using BookManagmentSystem.Repos.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorsController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorRepo.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _authorRepo.AddAuthor(authorDto);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAuthor = _authorRepo.GetAuthorById(id);
            if (existingAuthor == null)
                return NotFound();

            _authorRepo.UpdateAuthor(id, authorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var existingAuthor = _authorRepo.GetAuthorById(id);
            if (existingAuthor == null)
                return NotFound();

            _authorRepo.DeleteAuthor(id);
            return NoContent();
        }
    }
}
