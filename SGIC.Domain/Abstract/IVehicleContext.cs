using SGIC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Abstract
{
    public interface IVehicleContext
    {
        DbSet<Split> Splits { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<Extra> Extras { get; set; }
    }
}
