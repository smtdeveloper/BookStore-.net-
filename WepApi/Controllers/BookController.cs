using Microsoft.AspNetCore.Mvc;
using WepApi.DBOperations;
using WepApi.BookOperations;

namespace WepApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase 
    {
        private readonly BookStoreDbContext _context; 

        public BookController(BookStoreDbContext bookStoreDbContext)
        {
            _context = bookStoreDbContext;
        }

        [HttpGet("List")]
        public IActionResult GetBooks()
        {
             GetBooksQuery query = new GetBooksQuery(_context);
             var result =  query.Handle();
             return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BlogID = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(result);

            } 

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook )
        {
              CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.model = newBook;
                command.Handle();
                return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
           
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            try
            {
                command.BlogID = id;
                command.model = updateBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

             return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            
            try
            {
                command.BlogID = id;
                command.Handle();

            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }

            return Ok();
        }


    }
}