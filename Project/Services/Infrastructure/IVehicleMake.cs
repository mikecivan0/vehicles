using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Infrastructure
{
    public interface IVehicleMake
    {
        Task<List<VehicleMake>> GetVehicleMakesAsync(
            string sortOrder,
            string currentFilter,
            string searchString);
        Task<List<VehicleMake>> GetAllVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeByIdAsync(int Id);
        Task InsertVehicleMakeAsync(VehicleMake vehicleMake);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicleMake(VehicleMake vehicleMake);
        Task SaveVehicleMakeAsync();
    }
}
