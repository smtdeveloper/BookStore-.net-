using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.TokenOprations.Models;

namespace WebApi.TokenOprations
{
   
    public class TokenHandler
    {
        public IConfiguration _configuration {get; set;}
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecuritKey"]));
            SigningCredentials credentials = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            tokenModel.Experation = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: tokenModel.Experation,
                notBefore : DateTime.Now,
                signingCredentials : credentials
                
            );

            JwtSecurityTokenHandler  tokenHandler = new JwtSecurityTokenHandler();
            
            // Token Olusturuluyor.
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;


        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }


    }
}