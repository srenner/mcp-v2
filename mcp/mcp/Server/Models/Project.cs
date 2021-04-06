using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// Represents a project being applied to a vehicle, e.g. "Upgrade brakes"
    /// </summary>
    public class Project
    {
        public int ProjectID { get; set; }

        public int? ParentProjectID { get; set; }
        public Project ParentProject { get; set; }

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? UserCategoryID { get; set; }
        public UserCategory UserCategory { get; set; }

        [DataType(DataType.Currency)]
        public decimal? TargetCost { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ActualCost { get; set; }
        
        public DateTime? StartDate { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public bool IsComplete { get; set; }
        public bool IsPublic { get; set; }
        public bool IsCostPublic { get; set; }
        public bool IsDeleted { get; set; }

        public List<ProjectPart> Parts { get; set; }
        public List<ProjectDependency> Dependencies { get; set; }
        public List<ProjectDependency> DependenciesOf { get; set; }

        public List<Project> SubProjects { get; set; }

        public int GetProgress()
        {
            if (this.Parts != null)
            {
                if (this.Parts.Count == 0)
                {
                    return 0;
                }
                else
                {
                    int partCount = this.Parts.Count;
                    int partsPurchased = this.Parts.Sum(s => s.QuantityPurchased);
                    int partsInstalled = this.Parts.Sum(s => s.QuantityInstalled);
                    return ((partsPurchased + partsInstalled) / (partCount * 2)) * 100;
                }
            }
            else
            {
                return 0;
            }
        }

    }
}
