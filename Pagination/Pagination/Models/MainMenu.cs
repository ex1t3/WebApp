using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagination.Models
{
    public class MainMenu
    {
        public int Id { get; set; }
        public string Header { get; set; }  // заголовок меню
        public string Url { get; set; } // адрес ссылки
        public int? Order { get; set; }  // порядок следования пункта в подменю
        public int? ParentId { get; set; }  // ссылка на id родительского меню
        public MainMenu Parent { get; set; }    // родительское меню

       public ICollection<MainMenu> Children { get; set; }   // дочерние пункты меню
        public MainMenu()
        {
            Children = new List<MainMenu>();
        }
    }
}