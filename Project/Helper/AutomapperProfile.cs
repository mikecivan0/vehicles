using AutoMapper;
using Project.DAL.Models;
using Project.Models.ViewModels.VehicleMakeViewModels;
using Project.Models.ViewModels.VehicleModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>();
            CreateMap<VehicleMake, DetailsVehicleMakeViewModel>();
            CreateMap<VehicleMake, EditVehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleMake, DeleteVehicleMakeViewModel>().ReverseMap();
            CreateMap<CreateVehicleMakeViewModel, VehicleMake>();

            CreateMap<VehicleModel, VehicleModelViewModel>();
            CreateMap<VehicleModel, DetailsVehicleModelViewModel>();           
            CreateMap<VehicleModel, EditVehicleModelViewModel>().ReverseMap();
            CreateMap<VehicleModel, DeleteVehicleModelViewModel>().ReverseMap();
            CreateMap<CreateVehicleModelViewModel, VehicleModel>();
        }
    }
}
