using System;
using System.Collections.Generic;

#nullable disable

namespace Authentication_API.Models
{
    public partial class User
    {
       

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }

        public User(String newFirstName, String newLastName, String newEmail, String newPassword)
        {
            FirstName = newFirstName;
            LastName = newLastName;
            Email = newEmail;
            CurrentPassword = newPassword;
        }


    }
}
