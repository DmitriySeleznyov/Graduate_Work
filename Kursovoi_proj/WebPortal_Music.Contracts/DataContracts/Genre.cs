using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal_Music.Contracts.DataContracts
{
    public class Genre
    {
        [Key]
        public int Genre_Id { get; set; }
        public string Name_Genre { get; set; }

        public ICollection<Singer_Group> Singer_Groups { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
