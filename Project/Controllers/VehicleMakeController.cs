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
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString)
        {
            ViewData["CurrentFilter"] = searchString; 
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder!="name_desc" ? "name_desc" : "name_asc"; //change param for next sorting
            ViewData["NameFilter"] = searchString; //displaying search value in input


            var vehicleMakes = await _vehicleMake.GetVehicleMakesAsync(sortOrder, currentFilter, searchString);           
            var mappedVehicleMakes = _mapper.Map<List<VehicleMakeViewModel>>(vehicleMakes);

            return View(mappedVehicleMakes);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMake = await _vehicleMake.GetVehicleMakeByIdAsync(id);
            var mappedVehicleMake = _mapper.Map<EditVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var vehicleMake = await _vehicleMake.GetVehicleMakeByIdAsync(id);
            var mappedVehicleMake = _mapper.Map<DetailsVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleMake = await _vehicleMake.GetVehicleMakeByIdAsync(id);
            var mappedVehicleMake = _mapper.Map<DeleteVehicleMakeViewModel>(vehicleMake);
            return View(mappedVehicleMake);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            _vehicleMake.DeleteVehicleMake(mappedVehicleMakeInModel);
            await _vehicleMake.SaveVehicleMakeAsync();
            return RedirectToAction("Index", "VehicleMake");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            _vehicleMake.UpdateVehicleMake(mappedVehicleMakeInModel);
            await _vehicleMake.SaveVehicleMakeAsync();
            return RedirectToAction("Index", "VehicleMake");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVehicleMakeViewModel vm)
        {
            var mappedVehicleMakeInModel = _mapper.Map<VehicleMake>(vm);
            await _vehicleMake.InsertVehicleMakeAsync(mappedVehicleMakeInModel);
            await _vehicleMake.SaveVehicleMakeAsync();
            return RedirectToAction("Index", "VehicleMake");
        }

    }   
}
