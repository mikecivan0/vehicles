using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DAL.Models;
using Project.Models.ViewModels.VehicleMakeViewModels;
using Project.Services.Infrastructure;

namespace Project.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMake _vehicleMake;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMake vehicleMake, IMapper mapper)
        {
            _vehicleMake = vehicleMake;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var AllVehicleMakes = _vehicleMake.GetAllVehicleMakes();
            var mappedVehicleMakes = _mapper.Map<List<VehicleMakeViewModel>>(AllVehicleMakes);
            return View(mappedVehicleMakes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vehicleMake = _vehicleMake.GetVehicleMakeById(id);
            var mappedVehicleMake = _mapper.Map<EditVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var vehicleMake = _vehicleMake.GetVehicleMakeById(id);
            var mappedVehicleMake = _mapper.Map<DetailsVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vehicleMake = _vehicleMake.GetVehicleMakeById(id);
            var mappedVehicleMake = _mapper.Map<DeleteVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            _vehicleMake.DeleteVehicleMake(mappedVehicleMakeInModel);
            _vehicleMake.Save();
            return RedirectToAction("Index", "VehicleMake");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            _vehicleMake.UpdateVehicleMake(mappedVehicleMakeInModel);
            _vehicleMake.Save();
            return RedirectToAction("Index", "VehicleMake");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            _vehicleMake.InsertVehicleMake(mappedVehicleMakeInModel);
            _vehicleMake.Save();
            return RedirectToAction("Index", "VehicleMake");
        }

    }   
}
