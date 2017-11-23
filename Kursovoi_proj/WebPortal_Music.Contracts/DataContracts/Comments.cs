using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal_Music.Contracts.DataContracts
{
    public class Comments
    {
        [Key]
        public int Comment_Id { get; set; }
        public string Comment_Description { get; set; }
        public DateTime Date_Time { get; set; }
    }
}
