using mcp.Server.Models;
using mcp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.ModelExtensions
{
    public static class ProjectChecklistItemExtensions
    {
        public static ProjectChecklistItemViewModel ToViewModel(this ProjectChecklistItem item)
        {
            var model = new ProjectChecklistItemViewModel();

            model.Description = item.Description;
            //model.ParentProjectChecklistItem = item.ParentProjectChecklistItem.ToViewModel();
            //model.ParentProjectChecklistItemID = item.ParentProjectChecklistItemID;
            model.Project = item.Project.ToViewModel();
            model.ProjectChecklistItemID = item.ProjectChecklistItemID;
            model.ProjectID = item.ProjectID;
            model.SortOrder = item.SortOrder;
            model.IsChecked = item.IsChecked;

            return model;
        }

        public static List<ProjectChecklistItemViewModel> ToViewModel(this List<ProjectChecklistItem> items)
        {
            var list = new List<ProjectChecklistItemViewModel>();
            items.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }
    }
}
