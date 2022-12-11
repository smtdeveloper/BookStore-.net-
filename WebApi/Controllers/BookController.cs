
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOprations;
using WebApi.DbOprations;
using WebApi.Validator;
using WebApi.Validator.BookValidator;

namespace WebApi.AddController
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
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

            GetBookDetail query = new GetBookDetail(_context, _mapper);
            query.BookID = id;
            GetBookDetailValidator validator = new GetBookDetailValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();



            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBook command = new CreateBook(_context, _mapper);
            command.Model = newBook;

            CreateBookValidator validator = new CreateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();



        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel UpdateBook)
        {

            UpdateBook command = new UpdateBook(_context, _mapper);

            command.BookID = id;
            command.Model = UpdateBook;

            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();




            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBook command = new DeleteBook(_context);
            command.BookID = id;
            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }

}