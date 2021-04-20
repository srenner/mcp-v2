using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class ProjectListItemViewModel
    {
        public int ProjectID { get; set; }
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string Name { get; set; }
        public int? UserCategoryID { get; set; }
        public string UserCategory { get; set; }
        public string ProjectLink
        {
            get
            {
                return "/project/" + this.ProjectID;
            }
        }
    }

    public class ProjectViewModel
    {
        public int ProjectID { get; set; }
        public string ProjectLink
        {
            get
            {
                return "/project/" + this.ProjectID;
            }
        }

        public int? ParentProjectID { get; set; }
        public string ParentProjectName { get; set; }
        public string ParentProjectLink
        {
            get
            {
                if (this.ParentProjectID.HasValue)
                {
                    return "/project/" + this.ParentProjectID;
                }
                else return null;
            }
        }

        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleLink
        {
            get
            {
                return "/vehicle/" + this.VehicleID;
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string InstallationNotes { get; set; }

        public int? UserCategoryID { get; set; }
        public string UserCategory { get; set; }

        public decimal? TargetCost { get; set; }

        public decimal? ActualCost { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int ProjectStatusID { get; set; }

        public bool IsPublic { get; set; }
        public bool IsCostPublic { get; set; }
        public bool IsDeleted { get; set; }
        public int Progress { get; set; }

        public List<ProjectPartViewModel> Parts { get; set; }

        public List<ProjectListItemViewModel> Dependencies { get; set; }

        public List<ProjectListItemViewModel> BlockedProjects { get; set; }

        public List<ProjectListItemViewModel> SubProjects { get; set; }

        public List<ProjectChecklistItemViewModel> ChecklistItems { get; set; }



        #region budget calculations

        public decimal TotalCostSpent
        {
            get
            {
                decimal spent = 0.00M;

                spent += PartCostSpent;

                return spent;
            }
        }

        public decimal TotalPercentSpent
        {
            get
            {
                decimal percent = 0.00M;

                if(TargetCost.HasValue && TargetCost.Value > 0.00M)
                {
                    percent = (TotalCostSpent / TargetCost.Value);
                }
                return Math.Round(percent * 100);
            }
        }

        public string TotalPercentSpentString
        {
            get
            {
                return TotalPercentSpent.ToString() + "%";
            }
        }





        public decimal PartCostAllocated
        {
            get
            {
                decimal allocated = 0.00M;
                if(this.Parts != null && this.Parts.Count > 0 && this.Parts.Any(a => a.Price.HasValue))
                {
                    allocated = this.Parts.Sum(s => s.MoneyAllocated);
                }
                return allocated;
            }
        }

        public decimal PartCostSpent
        {
            get
            {
                decimal spent = 0.00M;
                if (this.Parts != null && this.Parts.Count > 0 && this.Parts.Any(a => a.Price.HasValue) && this.Parts.Any(a => a.QuantityPurchased > 0))
                {
                    spent = this.Parts.Sum(s => s.MoneySpent);
                }
                return spent;
            }
        }

        public decimal PartPercentSpent
        {
            get
            {
                var percent = 0.00M;
                if(this.Parts != null && this.Parts.Count > 0 && this.Parts.Any(a => a.Price.HasValue))
                {
                    var allocated = this.Parts.Sum(s => s.MoneyAllocated);
                    var spent = this.Parts.Sum(s => s.MoneySpent);
                    if(allocated > 0)
                    {
                        percent = (spent / allocated);
                    }
                }
                return Math.Round(percent * 100);
            }
        }

        public string PartPercentSpentString
        {
            get
            {
                return this.PartPercentSpent.ToString() + "%";
            }
        }


        #endregion




    }
}
