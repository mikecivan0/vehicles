using System.ComponentModel.DataAnnotations;

namespace Project.Service
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }

        [Required(ErrorMessage = "Please enter the valid name")]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public VehicleMake VehicleMake { get; set; }

    }
}