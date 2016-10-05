using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pagination.Models
{
    public class MainMenuInitializer : DropCreateDatabaseAlways<MainMenuContext>
    {
        protected override void Seed(MainMenuContext db)
        {
            var MainMenus = new List<MainMenu>()
            {
                new MainMenu {Id = 1, Header = "MAIN", Url = "/Home/Index", Order = 1},
                new MainMenu {Id = 2, Header = "ABOUT", Url = "/Home/About", Order = 2},
                new MainMenu {Id = 3, Header = "Contact", Url = "/Home/Contact", Order = 3},
                new MainMenu {Id = 4, Header = "Меню второго уровня 1", Url = "#", Order = 1, ParentId = 2},
                new MainMenu {Id = 5, Header = "Меню второго уровня 2", Url = "#", Order = 2, ParentId = 2},
                new MainMenu {Id = 6, Header = "Меню второго уровня 3", Url = "#", Order = 3, ParentId = 2},
                new MainMenu {Id = 7, Header = "Меню третьго уровня 1", Url = "#", Order = 1, ParentId = 4},
                new MainMenu {Id = 8, Header = "Меню третьго уровня 2dd", Url = "#", Order = 2, ParentId = 4},
                new MainMenu {Id = 9, Header = "Меню третьго уровня 3aa", Url = "#", Order = 3, ParentId = 4},
                new MainMenu {Children = new List<MainMenu>
                {
                    new MainMenu { Children =  new List<MainMenu> { new MainMenu {Id = 18, Header = "UNDER_UNDER", Url = "#", Order = 2, ParentId = 5 } },Id = 10, Header = "Just a menu by collection", Url = "#", Order = 1, ParentId = 5 },
                    new MainMenu { Children = new List<MainMenu>
                    {
                        new MainMenu{ Id = 14, Header = "UNDER", Url = "#", Order = 2, ParentId = 5 },
                        new MainMenu{ Id = 15, Header = "UNDER2", Url = "#", Order = 2, ParentId = 5 },
                        new MainMenu{ Children =  new List<MainMenu> { new MainMenu {Id = 16, Header = "UNDER_UNDER", Url = "#", Order = 2, ParentId = 5 } }, Id = 17, Header = "UNDER23", Url = "#", Order = 2, ParentId = 5 },
                    
                    },
                        Id = 12, Header = "Just a menu by collection1", Url = "#", Order = 3, ParentId = 5 },
                    new MainMenu { Id = 13, Header = "Just a menu by collection2", Url = "#", Order = 2, ParentId = 5 },
                    
                }, Id = 11, Header = "Collection", Url = "#", Order = 4},
            };
            db.mainMenus.AddRange(MainMenus);
            db.SaveChanges();
        }
    }
}