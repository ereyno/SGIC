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
                    select new Split
                    {
                        Id = s.Id,
                        CreateDateUtc = s.CreateDateUtc,
                        Expense = s.Credit,
                        Extras = (from e in Context.Extras where s.Id == e.SplitID select new Extra { Id = e.Id, Key = e.Key, SplitID = e.SplitID, Value = e.Value }).ToList(),
                        isReady = s.isReady,
                        name = s.name,
                        PersonID = s.PersonID,
                        StartDateUtc = s.StartDateUtc,
                        Toll = s.Toll,
                        Total = s.Total,
                        Credit = s.Credit,
                        Driver = new Person { Id = p.Id, Name = p.Name}
                    }).ToList();
        }

        public List<Split> GetAllSplitsByMonth(int month, int year)
        {
            return (from s in Context.Splits
                    join p in Context.People on s.PersonID equals p.Id
                    where s.StartDateUtc.Month == month && s.StartDateUtc.Year == year
                    select new Split
                    {
                        Id = s.Id,
                        CreateDateUtc = s.CreateDateUtc,
                        Expense = s.Credit,
                        Extras = (from e in Context.Extras where s.Id == e.SplitID select new Extra { Id = e.Id, Key = e.Key, SplitID = e.SplitID, Value = e.Value }).ToList(),
                        isReady = s.isReady,
                        name = s.name,
                        PersonID = s.PersonID,
                        StartDateUtc = s.StartDateUtc,
                        Toll = s.Toll,
                        Total = s.Total,
                        Credit = s.Credit,
                        Driver = new Person { Id = p.Id, Name = p.Name }
                    }).ToList();
        }

        public Split GetSingleSplit(DateTime date)
        {
            return (from s in Context.Splits
                    join p in Context.People on s.PersonID equals p.Id
                    where s.StartDateUtc == date
                    select new Split
                    {
                        Id = s.Id,
                        CreateDateUtc = s.CreateDateUtc,
                        Expense = s.Credit,
                        Extras = (from e in Context.Extras where s.Id == e.SplitID select new Extra { Id = e.Id, Key = e.Key, SplitID = e.SplitID, Value = e.Value }).ToList(),
                        isReady = s.isReady,
                        name = s.name,
                        PersonID = s.PersonID,
                        StartDateUtc = s.StartDateUtc,
                        Toll = s.Toll,
                        Total = s.Total,
                        Credit = s.Credit,
                        Driver = new Person { Id = p.Id, Name = p.Name }
                    }).First();
        }
    }
}
