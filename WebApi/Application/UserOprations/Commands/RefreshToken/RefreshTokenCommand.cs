using AutoMapper;
using WebApi.DbOprations;
using WebApi.TokenOprations;
using WebApi.TokenOprations.Models;

namespace WebApi.Application.UserOprations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public string RefrehToken;

        public RefreshTokenCommand(IBookStoreDbContext context, IConfiguration configuration)
        {
          
            _context = context;
            _configuration = configuration;
        }


        public Token Handle()
        {
           var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefrehToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı ! ");
            }
        }


    }
}
