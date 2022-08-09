using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries
{
    public class GetUsersQuery 
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public GetUsersQuery Model;

        public GetUsersQuery( IBookStoreDbContext context , IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public List<GetUsersModel> Handle()
        {
            var userList = _context.Users.Where(x => x.IsActive == true).ToList();

        
            List<GetUsersModel> model = _mapper.Map<List<GetUsersModel>>(userList);
            return model;
        }
    }
    
    public class GetUsersModel
    {
        public string Name { get; set; }
        public string  LastName { get; set; }
    }
}