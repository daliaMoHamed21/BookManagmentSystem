using BookManagmentSystem.DTOs;
using BookManagmentSystem.Repos.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepo _bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

       
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            return Ok(books); 
        }

       
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book == null)
                return NotFound(); 

            return Ok(book); 
        }

      
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDto)
        {
 
            _bookRepo.AddBook(bookDto);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            

            var Book = _bookRepo.GetBookById(id);
            if (Book == null)
                return NotFound(); 

            _bookRepo.UpdateBook(bookDto, id);
            return NoContent(); 
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var Book = _bookRepo.GetBookById(id);
            if (Book == null)
                return NotFound(); 

            _bookRepo.DeleteBook(id);
            return NoContent(); 
        }
    }
}
