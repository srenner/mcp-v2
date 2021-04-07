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
            model.Manufacturer = part.Manufacturer;
            model.Name = part.Name;
            model.PartNumber = part.PartNumber;
            model.Price = part.Price;
            model.MoneySpent = part.MoneySpent;
            model.ProjectID = part.ProjectID;
            model.ProjectPartID = part.ProjectPartID;
            model.Quantity = part.Quantity;
            model.QuantityPurchased = part.QuantityPurchased;
            model.QuantityInstalled = part.QuantityInstalled;
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
