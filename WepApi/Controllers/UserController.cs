using Microsoft.AspNetCore.Mvc;
using System;
using WepApi.DBOperations;

namespace WepApi.AddControllers
{  
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase 
    {
        private readonly BookStoreDbContext _context; 

        public UserController(BookStoreDbContext bookStoreDbContext)
        {
            _context = bookStoreDbContext;
        }

        [HttpGet("List")]
        public List<User> GetUser()
        {
            var user = _context.Users.OrderBy(x => x.ID).ToList<User>();
            return user;
            // return BookList;
        } 
        
        [HttpGet("GetByID")]
        public User GetByIDUser(int id)
        {
            var getByID = _context.Users.Where(x => x.ID == id).SingleOrDefault();
            return getByID;
        } 

        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser )
        {
            var user = _context.Users.SingleOrDefault(x => x.Name == newUser.Name);
            if(user != null)
                return BadRequest();
            
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] User updateUser)
        {
            var user = _context.Users.SingleOrDefault(x => x.ID == id);
            if(user == null)
                return BadRequest();
            
            user.Name = updateUser.Name != default ? updateUser.Name : user.Name;
            user.department = updateUser.department != default ? updateUser.department : user.department;
            user.City = updateUser.City != default ? updateUser.City : user.City;
            

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user =  _context.Users.SingleOrDefault(x => x.ID == id);
            if(user == null) 
            return BadRequest();
            
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

       


    }
}