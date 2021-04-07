using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class ProjectStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectStatusID { get; set; }
        public string Name { get; set; }
    }
}
