using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursovoi_proj.Models
{
    public class MusicModel
    {
        public int Song_Id { get; set; }

        public string Name_Song { get; set; }

        public string Singer { get; set; }

        public DateTime Time { get; set; }

    }
}