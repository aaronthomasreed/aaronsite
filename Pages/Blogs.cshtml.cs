using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronSite.AppCode;
using AaronSite.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AaronSite.Pages
{
    public class BlogsModel : PageControl
    {
        // Properties here

        public BlogsModel(Db context, Models.Page page, HttpContext httpContext)
        {
            _context = context;
            Page = page;
        }

        // Methods here
    }
}
