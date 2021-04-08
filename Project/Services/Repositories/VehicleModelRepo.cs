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

        public async Task<List<VehicleModel>> GetAllVehicleModelsAsync()
        {
            return await _context.VehicleModels.Include(v => v.VehicleMake).ToListAsync();
        }
        public async Task<List<VehicleModel>> SearchVehicleModelsAsync(string SearchName)
        {
            return await _context.VehicleModels.Include(v => v.VehicleMake)
                                                        .Where(x => x.Name.Contains(SearchName) || x.VehicleMake.Name.Contains(SearchName))
                                                        .ToListAsync();
        }

        public async Task<VehicleModel> GetVehicleModelByIdAsync(int Id)
        {
            return await _context.VehicleModels.Include(v => v.VehicleMake).Where(y => y.Id == Id).FirstOrDefaultAsync();
        }

        public async Task InsertVehicleModelAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
        }

        public async Task SaveVehicleModelAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
        }
    }
}
