using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_API.Models
{
    public class DataAccess
    {
        private String Connection { get; set; }

        public bool Validate(User user)
        {
            if (user.Email == "")
            {
                return false;
            }
            else
                return true;
        }

        public void Register(User user)
        {

        }

        public void Update(User user, int number)
        {

        }

        public void Delete(int number)
        {

        }

    }
}
