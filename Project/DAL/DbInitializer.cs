using Project.DAL.Models;
using Project.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(VehicleContext context)
        {
            context.Database.EnsureCreated();

            // Look for any VehicleMakes.
            if (context.VehicleMakes.Any())
            {
                return;   // DB has been seeded
            }

            var vehicleMakes = new VehicleMake[]
            {
                new VehicleMake{Name="Audi",Abrv=""},
                new VehicleMake{Name="BMW",Abrv=""},
                new VehicleMake{Name="Mercedes",Abrv=""},
                new VehicleMake{Name="Fiat",Abrv=""},
            };
            foreach (VehicleMake vm in vehicleMakes)
            {
                context.VehicleMakes.Add(vm);
            }
            context.SaveChanges();

            var vehicleModels = new VehicleModel[]
            {
                new VehicleModel{VehicleMakeId=1,Name="A1",Abrv=""},
                new VehicleModel{VehicleMakeId=1,Name="S3",Abrv=""},
                new VehicleModel{VehicleMakeId=2,Name="X5",Abrv=""},
                new VehicleModel{VehicleMakeId=2,Name="X7",Abrv=""},
                new VehicleModel{VehicleMakeId=3,Name="320",Abrv=""},
                new VehicleModel{VehicleMakeId=3,Name="A110",Abrv=""},
                new VehicleModel{VehicleMakeId=4,Name="Panda",Abrv=""},
                new VehicleModel{VehicleMakeId=4,Name="Punto",Abrv=""},
                new VehicleModel{VehicleMakeId=4,Name="500",Abrv=""}
            };
            foreach (VehicleModel c in vehicleModels)
            {
                context.VehicleModels.Add(c);
            }
            context.SaveChanges();
        }
    }
}
