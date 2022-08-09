using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Commands
{
    public class CreateUserCommand 
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public CreateUserModel Model;

        public CreateUserCommand( IBookStoreDbContext context , IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);


            if(user != null)
            throw new InvalidOperationException("Email zaten mevcut.");

            user = _mapper.Map<User>(Model);
        
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

}