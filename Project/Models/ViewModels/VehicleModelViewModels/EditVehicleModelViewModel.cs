using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels.VehicleModelViewModels
{
    public class EditVehicleModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int VehicleMakeId { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}
