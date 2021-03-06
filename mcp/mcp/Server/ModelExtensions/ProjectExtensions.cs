﻿using mcp.Server.Models;
using mcp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.ModelExtensions
{
    public static class ProjectExtensions
    {
        #region ProjectViewModel

        public static ProjectViewModel ToViewModel(this Project project)
        {
            var model = new ProjectViewModel();

            model.ActualCost = project.ActualCost;
            model.ActualEndDate = project.ActualEndDate;
            model.Description = project.Description;
            model.IsComplete = project.IsComplete;
            model.IsCostPublic = project.IsCostPublic;
            model.IsDeleted = project.IsDeleted;
            model.IsPublic = project.IsPublic;
            model.Name = project.Name;
            model.ProjectID = project.ProjectID;
            model.StartDate = project.StartDate;
            model.TargetCost = project.TargetCost;
            model.TargetEndDate = project.TargetEndDate;
            model.UserCategory = project.UserCategory?.Name;
            model.VehicleID = project.VehicleID;
            model.VehicleName = project.Vehicle?.Name;

            if(project.Parts?.Count > 0)
            {
                model.Parts = project.Parts.ToViewModel();
            }

            if(project.Dependencies?.Count > 0)
            {
                model.Dependencies = project.Dependencies.Select(s => s.DependsOnProject).ToList().ToListItemViewModel();
                //model.Dependencies = project.Dependencies.Select(s => s.Project).ToList().ToListItemViewModel();
            }

            return model;
        }

        public static List<ProjectViewModel> ToViewModel(this List<Project> projects)
        {
            var list = new List<ProjectViewModel>();
            projects.ForEach(x => list.Add(x.ToViewModel()));
            return list;
        }

        #endregion

        #region ProjectListItemViewModel

        public static ProjectListItemViewModel ToListItemViewModel(this Project project)
        {
            var model = new ProjectListItemViewModel();
            model.Name = project.Name;
            model.ProjectID = project.ProjectID;
            model.UserCategory = project.UserCategory != null ? project.UserCategory.Name : "";
            model.UserCategoryID = project.UserCategoryID;
            model.VehicleID = project.VehicleID;
            model.VehicleName = project.Vehicle != null ? project.Vehicle.Name : "";
            return model;
        }

        public static List<ProjectListItemViewModel> ToListItemViewModel(this List<Project> projects)
        {
            var list = new List<ProjectListItemViewModel>();
            projects.ForEach(x => list.Add(x.ToListItemViewModel()));
            return list;
        }

        #endregion
    }
}
