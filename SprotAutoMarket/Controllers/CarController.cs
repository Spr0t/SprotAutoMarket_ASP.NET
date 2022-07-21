using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SprotAutoMarket.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: CarController
        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            var response = await _carRepository.Select();
            var response1 = await _carRepository.GetByName("BMW");
            var response2 = await _carRepository.Get(2);

            var car = new Car()
            {
                Name = "Audi",
                Model = "Q5",
                Speed = 250,
                Price = 10000000,
                Description = "Exclusive car",
                Created = DateTime.Now

            };

            await _carRepository.Create(car);
            await _carRepository.Delete(car);



            return View(response);

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
        public ActionResult Delete(int id)
        {
            return View();
        }

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
