using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Authentication_API.Models;
using Microsoft.Data.SqlClient;

namespace Authentication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly COMP2001_DThomasContext _context;
        private static List<User> _users { get; set; } = new List<User>();

        private DataAccess dataAccess = new DataAccess();

        public UserController(COMP2001_DThomasContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult ValidateUser(String email, String password)
        {
            User user = new User();

            user.Email = email;
            user.CurrentPassword = password;
            if (GetValidation(user) == true)
            {
                return Ok("User Valid"); 
            }
            else return Unauthorized("User Invalid");



        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, String firstName, String lastName, String email, String password)
        {
            User user = new User();
            user.UserId = id;

            if(firstName != null)
            user.FirstName = firstName;

            if(lastName != null)
            user.LastName = lastName;

            if(email != null)
            user.Email = email;

            if(password != null)
            user.CurrentPassword = password;

            dataAccess.UpdateUser(user, id, _context);
            return NoContent();

        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostUser(String firstName, String lastName, String email, String password)
        {

            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.CurrentPassword = password;


            return Ok(Register(user));


        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {

            dataAccess.Delete(id, _context);




            return NoContent();
        }


        private bool GetValidation (User user)
        {
            if (dataAccess.Validate(user, _context) == true)
                return true;
            else
                return false;
        }
    

        private String Register(User user)
        {
          
            return dataAccess.Register(user, _context);

        }


    }
}
