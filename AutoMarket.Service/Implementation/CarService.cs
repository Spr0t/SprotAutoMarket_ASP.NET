using AutoMarket.DAL.Interfaces;
using AutoMarket.DAL.Repositories;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Service.Implementation
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new  BaseResponse<IEnumerable<Car>>();
            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseresponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseresponse.Description = "Not found";
                    baseresponse.StatusCode = StatusCode.NotFound;
                    return baseresponse;
                }
                baseresponse.Data = car;
                return baseresponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar] : {ex.Message} ",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseresponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetByName(name);
                if (car == null)
                {
                    baseresponse.Description = "Not found";
                    baseresponse.StatusCode = StatusCode.NotFound;
                    return baseresponse;
                }
                baseresponse.Data = car;
                return baseresponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName] : {ex.Message} ",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseresponse = new BaseResponse<bool>();

            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseresponse.Description = "Not found";
                    baseresponse.StatusCode = StatusCode.NotFound;
                    return baseresponse;
                }
                await _carRepository.Delete(car);
                return baseresponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message} ",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
        {
            var baseresponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Description = carViewModel.Description,
                    Created = carViewModel.Created,
                    Speed = carViewModel.Speed,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Name = carViewModel.Name,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[Delete] : {ex.Message} ",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseresponse;
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
            var baseresponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseresponse.StatusCode = StatusCode.NotFound;
                    baseresponse.Description = "Not found";
                    return baseresponse;
                }

                car.Description = model.Description;
                car.Created = model.Created;
                car.Speed = model.Speed;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Name = model.Name;
                //car.TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar);
               await _carRepository.Update(car);
                return baseresponse;
                 
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message} ",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseresponse;
        }
    }
}  
