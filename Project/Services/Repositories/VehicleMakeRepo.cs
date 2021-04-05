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

        public async Task<List<VehicleMake>> GetAllVehicleMakesAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int Id)
        {
            return await _context.VehicleMakes.Include(y => y.VehicleModels)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task InsertVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await _context.VehicleMakes.AddAsync(vehicleMake);
        }

        public async Task SaveVehicleMakeAsync()
        {
            await _context.SaveChangesAsync();

        }

        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
           _context.VehicleMakes.Update(vehicleMake);
        }
    }
}
