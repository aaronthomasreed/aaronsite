using AaronSite.Data;
using AaronSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AaronSite.AppCode
{
    public class Provider
    {
        private readonly Db _context;

        public Provider(Db context)
        {
            _context = context;
        }

        public IEnumerable<Page> GetChildren(Page page)
            => _context.Pages.Where(n => n.ParentId == page.Id);

        public IEnumerable<Page> GetSiblings(Page page)
            => _context.Pages.Where(n => n.ParentId == page.ParentId && n.Id != page.Id);
    }
}
