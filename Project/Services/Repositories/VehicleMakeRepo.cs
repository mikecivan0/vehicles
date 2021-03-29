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
    public class VehicleMakeRepo : IVehicleMake
    {
        private readonly VehicleContext _context;

        public VehicleMakeRepo(VehicleContext context)
        {
            _context = context;
        }

        public void DeleteVehicleMake(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Remove(vehicleMake);
        }

        public List<VehicleMake> GetAllVehicleMakes()
        {
            return _context.VehicleMakes.ToList();
        }

        public VehicleMake GetVehicleMakeById(int Id)
        {
            return _context.VehicleMakes.Include(y => y.VehicleModels)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == Id);
        }

        public void InsertVehicleMake(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Add(vehicleMake);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Update(vehicleMake);
        }
    }
}
