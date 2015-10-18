using SGIC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Abstract
{
    public interface ISplitRepository
    {
        IVehicleContext Context { get; set; }
        List<Split> GetAllSplits();
        List<Split> GetAllSplitsByMonth(int month, int year);
        Split GetSingleSplit(DateTime date);
        List<Person> GetAllDrivers();
        bool SaveSplit(Split obj);
    }
}
