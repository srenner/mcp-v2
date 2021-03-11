using mcp.Server.Models;
using mcp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.ModelExtensions
{
    public static class UserCategoryExtensions
    {

        public static UserCategoryViewModel ToViewModel(this UserCategory userCategory)
        {
            var model = new UserCategoryViewModel();
            model.BaseName = userCategory.BaseCategory != null ? userCategory.BaseCategory.Name : null;
            model.CategoryID = userCategory.CategoryID;
            model.IsDeleted = userCategory.IsDeleted;
            model.Name = userCategory.Name;
            model.SortOrder = userCategory.SortOrder;
            model.UserCategoryID = userCategory.UserCategoryID;
            return model;
        }

        public static List<UserCategoryViewModel> ToViewModel(this List<UserCategory> categories)
        {
            var list = new List<UserCategoryViewModel>();
            categories.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

    }
}
