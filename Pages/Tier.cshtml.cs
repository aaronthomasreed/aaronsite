using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronSite.AppCode;
using AaronSite.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AaronSite.Models;
using System.Reflection;

namespace AaronSite.Pages
{
    public class TierModel : TierControl
    {
        private readonly Db _context;

        public TierModel(Db context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var page = GetRequestedPage(_context);

            if (page == null)
                IsErrored = true;
            else
            {
                Template = page.Template.ViewName;
                ModelToPass = GetPageControl(_context, page);
            }

        }
    }
}
