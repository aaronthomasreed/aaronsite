using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AaronSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Db context)
        {
            if (context.Pages.Any())
            {
                return;   // DB has been seeded
            }

            context.Pages.Add(new Models.Page
            {
                Id = 1,
                PageTitle = "Home",
                ParentId = null,
                IsPublished = true,
                Slug = string.Empty,
                DatePublished = DateTime.Now,
            });

            context.SaveChanges();
        }
    }
}
