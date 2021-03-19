﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service
{
    public static class DbInitializer
    {
        public static void Initialize(VehicleService context)
        {
            context.Database.EnsureCreated();

            // Look for any VehicleMakes.
            if (context.VehicleMakes.Any())
            {
                return;   // DB has been seeded
            }

            var vehicleMake = new VehicleMake[]
            {
                new VehicleMake{Name="Audi",Abrv=""},
                new VehicleMake{Name="BMW",Abrv=""}
            };
            foreach (VehicleMake vm in vehicleMake)
            {
                context.VehicleMakes.Add(vm);
            }
            context.SaveChanges();

            var vehicleModels = new VehicleModel[]
            {
                new VehicleModel{MakeId=1,Name="A1",Abrv=""},
                new VehicleModel{MakeId=1,Name="S3",Abrv=""},
                new VehicleModel{MakeId=2,Name="X5",Abrv=""},
                new VehicleModel{MakeId=2,Name="X7",Abrv=""}
            };
            foreach (VehicleModel c in vehicleModels)
            {
                context.VehicleModels.Add(c);
            }
            context.SaveChanges();
        }
    }
}