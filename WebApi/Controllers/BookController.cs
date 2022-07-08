using Microsoft.AspNetCore.Mvc;
using WebApi.BookOprations;
using WebApi.BookOprations.GetBookQuery;
using WebApi.DbOprations;

namespace WebApi.AddController
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
          [HttpGet]
        public IActionResult GetBooks()
        { 
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailModel result;   
            try
            {
                 GetBookDetail query = new GetBookDetail(_context);
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
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBook command = new CreateBook(_context);
                command.Model = newBook;
                command.Handle();
                return Ok();

            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
            }

            [HttpPut("{id}")]
            public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel UpdateBook)
            {
                try
                {
                    UpdateBook command = new UpdateBook(_context);
                    command.BlogID = id;
                    command.Model = UpdateBook;
                    command.Handle();

                }
                catch (Exception ex)
                {
                    
                   return BadRequest(ex.Message);
                }

              
                return Ok();

            }

            [HttpDelete("{id}")]
            public IActionResult DeleteBook(int id)
            {
                try
                {
                     DeleteBook command = new DeleteBook(_context);
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