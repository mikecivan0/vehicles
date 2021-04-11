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
        public async Task<List<VehicleModel>> GetVehicleModelsAsync(
            string sortOrder,
            string currentFilter,
            string searchString)
        {
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            var vehicleModels = from v in _context.VehicleModels.Include(v => v.VehicleMake)
                                select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.Name.ToUpper().Contains(searchString.ToUpper())
                                                 || v.VehicleMake.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            vehicleModels = sortOrder switch
            {
                "name_desc" => vehicleModels.OrderByDescending(v => v.Name),
                "name_asc" => vehicleModels.OrderBy(v => v.Name),
                "make_asc" => vehicleModels.OrderBy(v => v.VehicleMake.Name),
                "make_desc" => vehicleModels.OrderByDescending(v => v.VehicleMake.Name),
                _ => vehicleModels.OrderBy(v => v.Name),
            };

            return await vehicleModels.AsNoTracking().ToListAsync();
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
