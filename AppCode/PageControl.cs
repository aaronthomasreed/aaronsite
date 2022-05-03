using AaronSite.Data;
using AaronSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Page = AaronSite.Models.Page;

namespace AaronSite.AppCode
{
    public class PageControl : PageModel
    {
        public Db _context;
        public new Page Page { get; set; }

        public PageControl(Db context, Page page, HttpContext httpContext)
        {
            _context = context;
            Page = page;
        }

        public PageControl()
        {
        }
    }
}
