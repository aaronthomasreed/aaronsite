using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronSite.Data;
using System.Data.Entity;
using AaronSite.Models;
using Page = AaronSite.Models.Page;

namespace AaronSite.AppCode
{

    public class TierControl : PageModel
    {
        public string Template { get; set; }
        public dynamic ModelToPass { get; set; }
        public bool IsErrored = false;

        public Page GetRequestedPage(Db context)
        {
            string requestUrl = HttpContext.Request.Path.ToString().TrimEnd('/');
            string[] slugs = requestUrl.Split("/", StringSplitOptions.RemoveEmptyEntries);

            Page page = context.Pages.FirstOrDefault(n => n.Slug == slugs.First() && n.ParentId == null);
            foreach (var slug in slugs.Skip(1))
                page = page.Children.FirstOrDefault(n => n.Slug == slug);

            return page;
        }

        public dynamic GetPageControl(Db context, Page page)
        {
            Type t = Type.GetType("AaronSite.Pages." + page.Template.ViewName + "Model");
            return Activator.CreateInstance(t, new object[] { context, page, HttpContext });
        }
    }
}
