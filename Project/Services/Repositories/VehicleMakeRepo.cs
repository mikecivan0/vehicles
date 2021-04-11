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

        public async Task<List<VehicleMake>> GetVehicleMakesAsync(
            string sortOrder,
            string currentFilter,
            string searchString)
        {
            var vehicleMakes = from vm in _context.VehicleMakes
                               select vm;

            if (searchString == null)
            {
                searchString = currentFilter;
            }
            

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(vm => vm.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            vehicleMakes = sortOrder switch
            {
                "name_desc" => vehicleMakes.OrderByDescending(vm => vm.Name),
                "name_asc" => vehicleMakes.OrderBy(vm => vm.Name),
                _ => vehicleMakes.OrderBy(vm => vm.Name),
            };
            return await vehicleMakes.AsNoTracking().ToListAsync();
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
