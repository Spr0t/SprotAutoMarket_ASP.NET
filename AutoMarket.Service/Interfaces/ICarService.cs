using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Service.Interfaces
{
    public interface ICarService
    {
        IBaseResponse<List<Car>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel, byte[]? image);
        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    } 
}
