using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Infrastructure
{
    public interface IVehicleMake
    {
        List<VehicleMake> GetAllVehicleMakes();
        VehicleMake GetVehicleMakeById(int Id);
        void InsertVehicleMake(VehicleMake vehicleMake);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicleMake(VehicleMake vehicleMake);
        void Save();
    }
}
