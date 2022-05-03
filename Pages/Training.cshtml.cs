using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AaronSite.AppCode;
using AaronSite.Data;
using AaronSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace AaronSite.Pages
{
    public class TrainingModel : PageControl
    {
        public JArray GradePyramid { get; set; }

        public string Discipline { get; set; }

        public TrainingModel(Db context, Models.Page page, HttpContext httpContext)
        {
            _context = context;
            Page = page;

            var qs = httpContext.Request.Query;

            var sportPreference = "YDS";
            var boulderPreference = "Font";

            GradePyramid = new JArray();
            var q = _context.ClimbEntries.AsQueryable();

            foreach (var item in GetPyramid(qs["dis"]))
            {
                JObject jObject = JObject.FromObject(new
                {
                    Grade = item.Key.Discipline == "Sport" ? (sportPreference == "French" ? item.Key.FrenchSport : item.Key.YDS) : (boulderPreference == "Font" ? item.Key.Font : item.Key.Hueco),
                    Count = item.Value,
                    Redpoint = q.Count(n => n.Grade == item.Key && n.Style == "Redpoint"),
                    Flash = q.Count(n => n.Grade == item.Key && n.Style == "Flash"),
                    Onsight = q.Count(n => n.Grade == item.Key && n.Style == "Onsight")
                });

                GradePyramid.Add(jObject);
            }
        }

        public ICollection<KeyValuePair<ClimbGrade, int>> GetPyramid(string dis)
        {
            var q = _context.ClimbEntries.AsQueryable();

            if (string.IsNullOrWhiteSpace(dis))
                q = q.Where(n => n.Discipline == "Boulder");
            else
                q = q.Where(n => n.Discipline == dis);

            return q.OrderBy(n => n.Grade.Order).Select(n => new KeyValuePair<ClimbGrade, int>(n.Grade, q.Count(a => a.Grade == n.Grade))).Distinct().ToList();
        }
    }
}
