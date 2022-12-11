
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.UserOperations.Commands;
using WebApi.Application.UserOperations.Queries;
using WebApi.Application.UserOprations.Commands.CreateToken;
using WebApi.Application.UserOprations.Commands.RefreshToken;
using WebApi.DbOprations;
using WebApi.TokenOprations.Models;
using WebApi.Validator.UserValidator;

namespace WebApi.AddController
{
    
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration =  configuration; 

        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery query = new GetUsersQuery(_context , _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailUser(int id)
        {
            GetDetailUserQuery query = new GetDetailUserQuery(_context , _mapper);
            query.UserID = id;

            GetDetailUserValidator rules = new GetDetailUserValidator();
            rules.ValidateAndThrow(query);
            
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel model )
        {
            CreateUserCommand command = new CreateUserCommand(_context , _mapper);
            command.Model = model;

            CreateUserValidator validator = new CreateUserValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken( [FromBody] CreateTokenModel login)
        {

            CreateTokenCommand command = new CreateTokenCommand(_context , _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
            
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefrehToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context , _configuration);
            command.RefrehToken  = token;
            var result = command.Handle();
            return result;
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id ,[FromBody] UpdateUserModel model)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context , _mapper);
            command.UserID = id;
            command.Model = model;

            UpdateUserValidator validator = new UpdateUserValidator();
            validator.ValidateAndThrow(command);


            command.Handle();
            return Ok();

        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserCommand command = new DeleteUserCommand(_context);
            command.UserID = id;

            DeleteUserValidator validator = new DeleteUserValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }
        
    }
}