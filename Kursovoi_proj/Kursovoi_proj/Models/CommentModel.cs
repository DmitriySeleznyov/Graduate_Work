using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursovoi_proj.Models
{
    public class CommentModel
    {
        public int Comment_Id { get; set; }

        public string Comment_Description { get; set; }

        public DateTime Date_Time { get; set; }

    }
}