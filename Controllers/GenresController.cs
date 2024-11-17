using BookManagmentSystem.DTOs;
using BookManagmentSystem.Repos.GenreRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo _genreRepo;

        public GenresController(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreRepo.GetAllGenres();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            var genre = _genreRepo.GetGenreById(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreDTO genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _genreRepo.AddGenre(genreDto);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] GenreDTO genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingGenre = _genreRepo.GetGenreById(id);
            if (existingGenre == null)
                return NotFound();

            _genreRepo.UpdateGenre(id, genreDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var existingGenre = _genreRepo.GetGenreById(id);
            if (existingGenre == null)
                return NotFound();

            _genreRepo.DeleteGenre(id);
            return NoContent();
        }
    }
}
