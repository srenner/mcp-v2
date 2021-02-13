using mcp.Server.Models;
using mcp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.ModelExtensions
{
    public static class VehicleExtensions
    {
        public static VehicleListItemViewModel ToListItemViewModel(this Vehicle vehicle)
        {
            var model = new VehicleListItemViewModel();
            model.VehicleID = vehicle.VehicleID;
            model.IsForSale = vehicle.IsForSale;
            model.IsSold = vehicle.IsSold;
            model.Name = vehicle.Name;
            model.ProjectCount = vehicle.Projects?.Count > 0 ? vehicle.Projects.Count : 0;
            model.ModificationCount = vehicle.Modifications?.Count > 0 ? vehicle.Modifications.Count : 0;
            return model;
        }

        public static List<VehicleListItemViewModel> ToListItemViewModel(this List<Vehicle> vehicles)
        {
            var list = new List<VehicleListItemViewModel>();
            vehicles.ForEach(x => list.Add(x.ToListItemViewModel()));
            return list;
        }
    }
}
