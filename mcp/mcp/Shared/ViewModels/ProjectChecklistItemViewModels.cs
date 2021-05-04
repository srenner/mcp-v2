using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class ProjectChecklistItemViewModel
    {
        public int ProjectChecklistItemID { get; set; }

        public int ProjectID { get; set; }
        public ProjectViewModel Project { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }
        public bool IsChecked { get; set; }

        public int ParentProjectChecklistItemID { get; set; }
        public ProjectChecklistItemViewModel ParentProjectChecklistItem { get; set; }
    }
}
