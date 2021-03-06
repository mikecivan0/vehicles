using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Infrastructure
{
    public interface IVehicleModel
    {
        Task<List<VehicleModel>> GetVehicleModelsAsync(
            string sortOrder,
            string currentFilter,
            string searchString);
        Task<List<VehicleModel>> GetAllVehicleModelsAsync();
        Task <VehicleModel> GetVehicleModelByIdAsync(int Id);
        Task InsertVehicleModelAsync(VehicleModel vehicleModel);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(VehicleModel vehicleModel);
        Task SaveVehicleModelAsync();
    }
}
