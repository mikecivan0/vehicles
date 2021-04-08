using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DAL.Models;
using Project.Models.ViewModels.VehicleModelViewModels;
using Project.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModel _vehicleModel;
        private readonly IMapper _mapper;
        private readonly IVehicleMake _vehicleMake;

        public VehicleModelController(IVehicleModel vehicleModel, IMapper mapper, IVehicleMake vehicleMake)
        {
            _vehicleModel = vehicleModel;
            _mapper = mapper;
            _vehicleMake = vehicleMake;
        }

        // GET: VehicleModelController
        [HttpGet]
        public async Task<ActionResult> Index(string SearchName, List<VehicleModel> VehicleModels)
        {
            if (!String.IsNullOrEmpty(SearchName))
            {
                VehicleModels = await _vehicleModel.SearchVehicleModelsAsync(SearchName);
            }
            else
            {
                VehicleModels = await _vehicleModel.GetAllVehicleModelsAsync();
            }

            var mappedVehicleModels = _mapper.Map<List<VehicleModelViewModel>>(VehicleModels);
            return View(mappedVehicleModels);
        }

        // GET: VehicleModelController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var vehicleModel = await _vehicleModel.GetVehicleModelByIdAsync(id);
            var mappedVehicleModel = _mapper.Map<DetailsVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // GET: VehicleModelController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["VehicleMakeId"] = new SelectList(await _vehicleMake.GetAllVehicleMakesAsync(), "Id", "Name");            
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            await _vehicleModel.InsertVehicleModelAsync(mappedVehicleModelInModel);
            await _vehicleModel.SaveVehicleModelAsync();
            return RedirectToAction("Index", "VehicleModel");  
        }

        // GET: VehicleModelController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["VehicleMakeId"] = new SelectList(await _vehicleMake.GetAllVehicleMakesAsync(), "Id", "Name");
            var vehicleModel = await _vehicleModel.GetVehicleModelByIdAsync(id);
            var mappedVehicleModel = _mapper.Map<EditVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            _vehicleModel.UpdateVehicleModel(mappedVehicleModelInModel);
            await _vehicleModel.SaveVehicleModelAsync();
            return RedirectToAction("Index", "VehicleModel");
        }

        // GET: VehicleModelController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var vehicleModel = await _vehicleModel.GetVehicleModelByIdAsync(id);
            var mappedVehicleModel = _mapper.Map<DeleteVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            _vehicleModel.DeleteVehicleModel(mappedVehicleModelInModel);
           await _vehicleModel.SaveVehicleModelAsync();
            return RedirectToAction("Index", "VehicleModel");
        }
    }
}
