using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal_Music.Contracts.DataContracts
{
    public class Singer_Group
    {
        [Key]
        public int Singer_id { get; set; }
        public string Name_Singer { get; set; }
        public string Genre { get; set; }//
        public int Year_Create { get; set; }
    }
}
