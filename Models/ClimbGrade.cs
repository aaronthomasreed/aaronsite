using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AaronSite.Models
{
    public class ClimbGrade
    {
        [Key]
        public int Id { get; set; }

        public string Hueco { get; set; } = string.Empty;

        public string Font { get; set; } = string.Empty;

        public string YDS { get; set; } = string.Empty;

        public string FrenchSport { get; set; } = string.Empty;

        public string Discipline { get; set; } = string.Empty;

        [DefaultValue(0)]
        public int Order { get; set; }
    }
}
