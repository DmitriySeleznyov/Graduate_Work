using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursovoi_proj.Models
{
    public class UserModel
    {
        public int UsersID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public string Email { get; set; }
      
        public long Phone { get; set; }
       
    }
}