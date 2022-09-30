using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.ViewModels.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public int Speed { get; set; }
        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public string TypeCar { get; set; }

        public IFormFile Avatar { get; set; }

        public byte[]? Image { get; set; }
    }
}
