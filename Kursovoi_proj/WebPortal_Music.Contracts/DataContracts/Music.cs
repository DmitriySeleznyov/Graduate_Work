using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal_Music.Contracts.DataContracts
{
    public class Music
    {
        [Key]
        public int Song_Id { get; set; }
        public string Name_Song { get; set; }
        public string Singer { get; set; }//певец или группа
        public string Time { get; set; }

    }
}
