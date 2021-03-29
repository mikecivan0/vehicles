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
        public ActionResult Index()
        {
            var AllVehicleModels = _vehicleModel.GetAllVehicleModels();
            var mappedVehicleModels = _mapper.Map<List<VehicleModelViewModel>>(AllVehicleModels);
            return View(mappedVehicleModels);
        }

        // GET: VehicleModelController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var vehicleModel = _vehicleModel.GetVehicleModelById(id);
            var mappedVehicleModel = _mapper.Map<DetailsVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // GET: VehicleModelController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["VehicleMakeId"] = new SelectList(_vehicleMake.GetAllVehicleMakes(), "Id", "Name");            
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            _vehicleModel.InsertVehicleModel(mappedVehicleModelInModel);
            _vehicleModel.Save();
            return RedirectToAction("Index", "VehicleModel");  
        }

        // GET: VehicleModelController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["VehicleMakeId"] = new SelectList(_vehicleMake.GetAllVehicleMakes(), "Id", "Name");
            var vehicleModel = _vehicleModel.GetVehicleModelById(id);
            var mappedVehicleModel = _mapper.Map<EditVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            _vehicleModel.UpdateVehicleModel(mappedVehicleModelInModel);
            _vehicleModel.Save();
            return RedirectToAction("Index", "VehicleModel");
        }

        // GET: VehicleModelController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var vehicleModel = _vehicleModel.GetVehicleModelById(id);
            var mappedVehicleModel = _mapper.Map<DeleteVehicleModelViewModel>(vehicleModel);
            return View(mappedVehicleModel);
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteVehicleModelViewModel vm)
        {
            var mappedVehicleModelInModel = _mapper.Map<VehicleModel>(vm);
            _vehicleModel.DeleteVehicleModel(mappedVehicleModelInModel);
            _vehicleModel.Save();
            return RedirectToAction("Index", "VehicleModel");
        }
    }
}
