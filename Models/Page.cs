using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;

namespace AaronSite.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("NULL")]
        [ForeignKey(nameof(ParentPage))]
        public int? ParentId { get; set; }

        [DefaultValue("NULL")]
        [ForeignKey(nameof(Template))]
        public int? TemplateId { get; set; }

        public string PageTitle { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public DateTime DatePublished { get; set; }

        [DefaultValue(0)]
        public bool IsPublished { get; set; }

        [Computed]
        public virtual string Url => ParentPage?.Url + "/" + Slug;

        public virtual Page ParentPage { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<Page> Children { get; set; }
        public virtual Template Template { get; set; }
    }
}
