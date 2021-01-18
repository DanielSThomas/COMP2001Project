using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Authentication_API.Models
{
    public class DataAccess
    {
        

        public bool Validate(User user, COMP2001_DThomasContext _context)
        {
            SqlParameter returnvalue = new SqlParameter("@returnvalue", SqlDbType.Int);
            
            returnvalue.Direction = ParameterDirection.Output;
            returnvalue.Size = 4000;

            var storedProcedure = _context.Database.ExecuteSqlRaw("EXEC usp_validateuser @email, @password, @returnvalue OUT",   
           new SqlParameter("@email", user.Email),
           new SqlParameter("@password", user.CurrentPassword), returnvalue);

            try
            {
                if (returnvalue.SqlValue.ToString().Equals("1"))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public string Register(User user, COMP2001_DThomasContext _context)
        {
            
            SqlParameter message = new SqlParameter("@message", SqlDbType.VarChar);
            message.Direction = ParameterDirection.Output;
            message.Size = 4000;
            try
            {
                

                var storedProcedure = _context.Database.ExecuteSqlRaw("EXEC usp_register @newFirstName, @newLastName, @newEmail, @newPassword, @message OUT",
            new SqlParameter("@newFirstName", user.FirstName),
            new SqlParameter("@newLastName", user.LastName),
            new SqlParameter("@newEmail", user.Email),
            new SqlParameter("@newPassword", user.CurrentPassword),
            message);
                return message.SqlValue.ToString();
               
       
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

        public void Delete(int selecteduser, COMP2001_DThomasContext _context)
        {
            var storedProcedure = _context.Database.ExecuteSqlRaw("EXEC dbo.usp_deleteuser @userID",
           new SqlParameter("@userID", selecteduser));
                          
        }

    }
}
