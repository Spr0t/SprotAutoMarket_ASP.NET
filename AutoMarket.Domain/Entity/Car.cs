﻿using AutoMarket.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.Entity
{
    public class Car
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public int Speed { get; set; }
        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public TypeCar TypeCar { get; set; }

        public byte[]? Avatar { get; set; }
    }

 
}
