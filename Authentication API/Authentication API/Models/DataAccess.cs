using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Authentication_API.Models
{
    public class DataAccess
    {
        public String Connection { get; set; }


        public bool Validate(User user)
        {
            if (user.Email == "")
            {
                return false;
            }
            else
                return true;
        }

        public int Register(User user, COMP2001_DThomasContext _context)
        {
            try
            {
                var storedProcedure = _context.Database.ExecuteSqlRaw("EXEC usp_register @newFirstName, @newLastName, @newEmail, @newPassword",
            new SqlParameter("@newFirstName", user.FirstName),
            new SqlParameter("@newLastName", user.LastName),
            new SqlParameter("@newEmail", user.Email),
            new SqlParameter("@newPassword", user.CurrentPassword));

                return storedProcedure;
       
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateUser(User user, int selecteduser, COMP2001_DThomasContext _context)
        {
            try
            {
                var storedProcedure = _context.Database.ExecuteSqlRaw("EXEC dbo.usp_updateuser @userID,  @newFirstName, @newLastName, @newEmail, @newPassword",
            new SqlParameter("@userID", selecteduser),
            new SqlParameter("@newFirstName", user.FirstName),
            new SqlParameter("@newLastName", user.LastName),
            new SqlParameter("@newEmail", user.Email),
            new SqlParameter("@newPassword", user.CurrentPassword));

                
            }
            catch (Exception)
            {

               throw;
            }

        }

        public void Delete(int number)
        {

        }

    }
}
