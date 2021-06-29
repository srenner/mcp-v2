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

        #region VehicleListItemViewModel

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

        #endregion

        #region VehicleViewModel

        public static VehicleViewModel ToViewModel(this Vehicle vehicle)
        {
            var model = new VehicleViewModel();
            model.VehicleID = vehicle.VehicleID;
            model.EstimatedValue = vehicle.EstimatedValue;
            model.ForSaleAskingPrice = vehicle.ForSaleAskingPrice;
            model.ForSaleLink = vehicle.ForSaleLink;
            model.ForSaleTransactionPrice = vehicle.ForSaleTransactionPrice;
            model.IsDeleted = vehicle.IsDeleted;
            model.IsForSale = vehicle.IsForSale;
            model.IsSold = vehicle.IsSold;
            model.Name = vehicle.Name;
            model.Notes = vehicle.Notes;
            model.PurchaseDate = vehicle.PurchaseDate;
            model.PurchasePrice = vehicle.PurchasePrice;
            model.TotalInvested = vehicle.TotalInvested;
            if(vehicle.User != null)
            {
                model.UserDisplayName = vehicle.User.DisplayName;
                model.UserID = vehicle.UserID;
                model.UserUniqueName = vehicle.User.UniqueName;
            }
            return model;
        }

        public static List<VehicleViewModel> ToViewModel(this List<Vehicle> vehicles)
        {
            var list = new List<VehicleViewModel>();
            vehicles.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

        #endregion



    }
}
