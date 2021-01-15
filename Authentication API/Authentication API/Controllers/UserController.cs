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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
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
        public IActionResult PutUser(int id, String newFirstName, String newLastName, String newEmail, String newPassword)
        {
            User user = new User();
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Email = newEmail;
            user.CurrentPassword = newPassword;

            dataAccess.UpdateUser(user, id, _context);
            return Accepted("Update Successful on User: " + id);

        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostUser(String newFirstName, String newLastName, String newEmail, String newPassword)
        {

            User user = new User();
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Email = newEmail;
            user.CurrentPassword = newPassword;


            return Accepted(Register(user));


        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private bool GetValidation (User user)
        {

            return false;
        }
    

        private String Register(User user)
        {
            if (dataAccess.Register(user, _context) == 1)
            {
                return "Register Successful";                
            }

            else
            {
                return "Register Unsuccessful";          
            }

        }


    }
}
