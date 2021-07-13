using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class ProjectShoppingListViewModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public List<ProjectPartViewModel> Parts { get; set; }

        /// <summary>
        /// calculated based on parts left to buy in the current project
        /// </summary>
        public decimal PendingPartCost { get; set; }
    }
}
