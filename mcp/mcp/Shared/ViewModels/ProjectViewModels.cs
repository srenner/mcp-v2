﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    class ProjectListItemViewModel
    {

    }

    public class ProjectViewModel
    {
        public int ProjectID { get; set; }

        public int VehicleID { get; set; }
        public string VehicleName { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? UserCategoryID { get; set; }
        public string UserCategory { get; set; }

        public decimal? TargetCost { get; set; }

        public decimal? ActualCost { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public bool IsComplete { get; set; }
        public bool IsPublic { get; set; }
        public bool IsCostPublic { get; set; }
        public bool IsDeleted { get; set; }
    }
}
