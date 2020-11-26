using System;
using System.Collections.Generic;

#nullable disable

namespace Authentication_API.Models
{
    public partial class Password
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string PreviousPassword { get; set; }
        public DateTime TimeChanged { get; set; }

        public virtual User User { get; set; }
    }
}
