using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class UserCategoryViewModel
    {
        public int UserCategoryID { get; set; }
        public int? CategoryID { get; set; }
        public string BaseName { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
}
