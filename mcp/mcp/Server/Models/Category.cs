using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// Type of project, e.g. "Engine", "Suspension", etc. This is the base list that every user will receive before they add/edit/remove categories.
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
