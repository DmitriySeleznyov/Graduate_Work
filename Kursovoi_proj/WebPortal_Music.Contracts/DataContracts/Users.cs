using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPortal_Music.Contracts.DataContracts
{
    public class Users
    {
        [Key]
        public int UsersID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
       
        public ICollection<Music> Musics { get; set; }

        public ICollection<Comments> Comment { get; set; }

    }
}
