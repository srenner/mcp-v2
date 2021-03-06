﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// Represents when a project requires a different project to be completed first
    /// </summary>
    public class ProjectDependency
    {
        public int ProjectDependencyID { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public int DependsOnProjectID { get; set; }
        public Project DependsOnProject { get; set; }
    }
}
