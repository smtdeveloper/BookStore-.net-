using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries
{
    public class GetDetailUserQuery 
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public int UserID;

        public GetDetailUserQuery(IBookStoreDbContext context , IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        public DetailUserModel Handle()
        {
            var user = _context.Users.Where(x => x.Id == UserID);

            if(user != null)
            throw new InvalidOperationException(" Kullanıcı Bulunamadı ! ");

            DetailUserModel model = _mapper.Map<DetailUserModel>(user);
            
            return model;
        
        }
    }

    public class DetailUserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
    }


}
