using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Commands
{
    public class UpdateUserCommand 
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public UpdateUserModel Model;
        public int UserID;

        public UpdateUserCommand( IBookStoreDbContext context , IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
    {
        var user = _context.Users.Find(UserID);

        if(user == null)
        throw new InvalidOperationException("Kullanıcı bulunamadı ! ");
        
        _mapper.Map<UpdateUserModel , User>(Model , user);
        _context.SaveChanges();
        
        // if(_context.SaveChanges() > 0 is false)
        // {
        //     throw new InvalidOperationException("işlem Başarasız ! ");
        // }
       

    }

    }

    


    public class UpdateUserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        
    }
    
}