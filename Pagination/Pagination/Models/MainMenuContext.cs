using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pagination.Models
{
    public class MainMenuContext: DbContext
    {
       public MainMenuContext() : base("DefaultConnection") { }
        public DbSet<MainMenu> mainMenus { get; set; }
    }
}