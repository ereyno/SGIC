using SGIC.Domain.Abstract;
using SGIC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Repository
{
    public class SplitRepository : ISplitRepository
    {
        public IVehicleContext Context { get; set;}

        public SplitRepository(IVehicleContext cont)
        {
            Context = cont;
        }
        public List<Split> GetAllSplits()
        {
            return (from s in Context.Splits
                    join p in Context.People on s.PersonID equals p.Id
                    select s).ToList();
        }

        public List<Split> GetAllSplitsByMonth(int month, int year)
        {
            return (from s in Context.Splits
                    where s.StartDateUtc.Month == month && s.StartDateUtc.Year == year
                    select s).ToList();
        }

        public Split GetSingleSplit(DateTime date)
        {
            return (from s in Context.Splits
                    join p in Context.People on s.PersonID equals p.Id
                    where s.StartDateUtc == date
                    select s).First();
        }

        public List<Person> GetAllDrivers()
        {
            return Context.People.ToList();
        }

        public bool SaveSplit(Split obj)
        {
            bool retval = false;
            try
            {
                this.Context.Splits.Add(obj);
                obj.Id = this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                retval = false;
            }
            return retval;
        }
    }
}
