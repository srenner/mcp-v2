using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class ProjectChecklistItem
    {
        public int ProjectChecklistItemID { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public bool IsChecked { get; set; }
        public DateTime? CheckedDateTime { get; set; }

        //public int ParentProjectChecklistItemID { get; set; }
        //public ProjectChecklistItem ParentProjectChecklistItem { get; set; }
    }
}
