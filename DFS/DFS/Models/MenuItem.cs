using DFS.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.Models
{
    public class MenuItem : BaseModel
    {
        public MenuItem()
        {
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}
