﻿using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SprotAutoMarket.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }



        // GET: CarController
        [HttpGet]
        public IActionResult GetCars()
        {
            var response =  _carService.GetCars();
            if (response.StatusCode == AutoMarket.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            if (response.StatusCode == AutoMarket.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == AutoMarket.Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            } 
            return RedirectToAction("Error");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _carService.GetCar(id);
            if (response.StatusCode == AutoMarket.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                        await _carService.CreateCar(model, imageData);
                }
                else
                {
                    await _carService.Edit(model.Id, model);
                }
            }
            return RedirectToAction("GetCars");
        }


        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5


        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
