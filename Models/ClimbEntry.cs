using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AaronSite.Models
{
    public class ClimbEntry
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("NULL")]
        [ForeignKey(nameof(Grade))]
        public int? GradeId { get; set; }

        public string Style { get; set; } = string.Empty;

        [DefaultValue(0)]
        public bool IsIndoors { get; set; }

        public string Discipline { get; set; } = string.Empty;

        public virtual ClimbGrade Grade { get; set; }
    }
}
