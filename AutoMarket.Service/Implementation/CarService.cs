using AutoMarket.DAL.Interfaces;
using AutoMarket.DAL.Repositories;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Service.Implementation
{
    public class CarService : ICarService
    {

        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository; 
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
            var baseresponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "Информация не найдена",
                        StatusCode = StatusCode.NotFound
                    };
                }

                var data = new CarViewModel()
                {
                    Created = car.Created,
                    Description = car.Description,
                    TypeCar = car.TypeCar.ToString(),
                    Speed = car.Speed,
                    Model = car.Model
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                    
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<CarViewModel>()
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
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(name));
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
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel, byte[]? image)
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
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar),
                    //Avatar = image
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
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
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
        }
    }
}  
