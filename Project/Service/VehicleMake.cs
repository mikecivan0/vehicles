using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleMake
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the valid name")]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }

    }
}
