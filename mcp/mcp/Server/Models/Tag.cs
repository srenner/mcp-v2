using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// Tag for a vehicle's overall theme, e.g. "Street/Strip", but the user can choose more than one per vehicle
    /// </summary>
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
}
