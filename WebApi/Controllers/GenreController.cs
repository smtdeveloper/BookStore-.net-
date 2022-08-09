
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOprations;
using WebApi.Application.GenreOperations.Commands;
using WebApi.Application.GenreOperations.Queries;
using WebApi.DbOprations;
using WebApi.Validator.GenreValidator;

namespace WebApi.AddController
{ 
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenre()
        {
            GetGenreQuery query = new GetGenreQuery(_context,_mapper);
            var genres = query.Handle();
            return Ok(genres);

        }

         [HttpGet("{id}")]
        public ActionResult GetByIdGenre(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId = id;
            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            validator.ValidateAndThrow(query);

            var genre = query.Handle();
            return Ok(genre);

        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = model;

            CreateGenreValidator validator = new CreateGenreValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = model;
            
            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreValidator rules = new DeleteGenreValidator();
            rules.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }


    }


}