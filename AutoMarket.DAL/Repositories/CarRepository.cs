using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await _db.Car.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            var result = await _db.Car.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ArgumentException("Возврат пустой ссылки");
            }
            else
            {
                return result;
            }
        }

        public async Task<Car> GetByName(string name)
        {
            var result = await _db.Car.FirstOrDefaultAsync(x => x.Name.Equals(name));
            if (result == null)
            {
                throw new ArgumentException("Возврат пустой ссылки");
            }
            else
            {
                return result;
            }
        }

        public Task<List<Car>> Select()
        {
            return _db.Car.ToListAsync();
        }

        public async Task<Car> Update(Car entity)
        {
           _db.Car.Update(entity);
           await _db.SaveChangesAsync();
            return entity;
        }
    }
}
