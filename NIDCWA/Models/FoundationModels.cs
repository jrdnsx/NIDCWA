using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NIDCWA.Models
{
    public class ObjectViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Active")]
        public byte active { get; set; }
    }
}