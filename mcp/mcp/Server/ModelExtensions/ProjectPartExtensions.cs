using mcp.Server.Models;
using mcp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.ModelExtensions
{
    public static class ProjectPartExtensions
    {
        public static ProjectPartViewModel ToViewModel(this ProjectPart part)
        {
            var model = new ProjectPartViewModel();
            model.Description = part.Description;
            model.Link = part.Link;
            model.Name = part.Name;
            model.Price = part.Price;
            model.ProjectID = part.ProjectID;
            model.ProjectPartID = part.ProjectPartID;
            model.Quantity = part.Quantity;
            model.QuantityPurchased = part.QuantityPurchased;
            return model;
        }

        public static List<ProjectPartViewModel> ToViewModel(this List<ProjectPart> parts)
        {
            var list = new List<ProjectPartViewModel>();
            parts.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }
    }
}
