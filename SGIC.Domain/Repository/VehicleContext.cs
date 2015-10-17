﻿using SGIC.Domain.Abstract;
using SGIC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Repository
{

    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext()
        {
            Database.SetInitializer<VehicleContext>(null);
        }

        public DbSet<Split> Splits { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Extra> Extras { get; set; }
    }
}