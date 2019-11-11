using System;
using System.Collections.Generic;
using AppCore.Entities;
using AppCore.Interfaces;
using Web.ApiModels.TerraristicsWindows;
using System.Linq;

namespace Web.Services
{
    public class TerraristicsWindowModelService
    {
        public TerraristicsWindowModelService()
        {
            
        }

        public TerraristicWindow CreateTerraristicsWindow(TerraristicsWindowApiModel apiModel, string userId)
        {
            var newTerraristicsWindow = new TerraristicWindow
            {
                ApiKey = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Name = apiModel.Name,
                Description = apiModel.Description,
            };

            return newTerraristicsWindow;
        }
    }
}