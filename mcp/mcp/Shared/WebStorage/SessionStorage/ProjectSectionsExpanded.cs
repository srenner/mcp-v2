using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.WebStorage.SessionStorage
{
    public class ProjectSectionsExpanded
    {
        public int ProjectID { get; set; }
        public bool IsPartsExpanded { get; set; }
        public bool IsRelatedExpanded { get; set; }
        public bool IsPartsDeciderExpanded { get; set; }
    }
}
