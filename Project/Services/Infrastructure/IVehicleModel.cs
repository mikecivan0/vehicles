using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Infrastructure
{
    public interface IVehicleModel
    {
        List<VehicleModel> GetAllVehicleModels();
        VehicleModel GetVehicleModelById(int Id);
        void InsertVehicleModel(VehicleModel vehicleModel);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(VehicleModel vehicleModel);
        void Save();
    }
}
