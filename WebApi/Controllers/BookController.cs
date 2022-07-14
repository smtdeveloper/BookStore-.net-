
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOprations;
using WebApi.BookOprations.GetBookQuery;
using WebApi.DbOprations;
using WebApi.Validator;

namespace WebApi.AddController
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
          [HttpGet]
        public IActionResult GetBooks()
        { 
            GetBookQuery query = new GetBookQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailModel result;   
            try
            {
                 GetBookDetail query = new GetBookDetail(_context, _mapper);
            query.BlogID = id;
            GetBookDetailValidator validator = new GetBookDetailValidator();
            validator.ValidateAndThrow(query);
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
                CreateBook command = new CreateBook(_context, _mapper);
                command.Model = newBook;
                CreateBookValidator validator =  new CreateBookValidator();
                validator.ValidateAndThrow(command);
                
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
                    UpdateBookValidator validator = new UpdateBookValidator();
                    validator.ValidateAndThrow(command);
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
                DeleteBookValidator validator = new DeleteBookValidator();
                validator.ValidateAndThrow(command);
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