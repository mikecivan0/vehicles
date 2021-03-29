using Microsoft.EntityFrameworkCore;
using Project.DAL.Models;
using Project.Services.Data;
using Project.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services.Repositories
{
    public class VehicleModelRepo : IVehicleModel
    {
        private readonly VehicleContext _context;

        public VehicleModelRepo(VehicleContext context)
        {
            _context = context;
        }

        public void DeleteVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
        }

        public List<VehicleModel> GetAllVehicleModels()
        {
            return _context.VehicleModels.Include(v => v.VehicleMake).ToList();
        }

        public VehicleModel GetVehicleModelById(int Id)
        {
            return _context.VehicleModels.Include(v => v.VehicleMake).Where(y => y.Id == Id).FirstOrDefault();
        }

        public void InsertVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Add(vehicleModel);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
        }
    }
}
