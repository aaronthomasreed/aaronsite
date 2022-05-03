using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AaronSite.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }

        public string ViewName { get; set; }
    }
}
