using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{

    /// <summary>
    /// Project category ("Engine", "Suspension", etc.) that is custom for each user.
    /// </summary>
    public class UserCategory
    {
        public int UserCategoryID { get; set; }

        public int? CategoryID { get; set; }
        public Category BaseCategory { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
}
