using AutoMapper;
using SGIC.Domain.Abstract;
using SGIC.Domain.Entities;
using SGIC.UI.Abstract;
using SGIC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.UI.Presenter
{
    public class SplitPresenter
    {
        public ISplitView view = null;
        public ISplitRepository repo = null;
        private SplitModel split;
        // (primitive) maintenance of state:
        private int currentIndex = 0;
        private bool isNew = true;
        private List<Person> people = null;

        public SplitPresenter(ISplitView view, ISplitRepository repo)
        {
            this.view = view;
            this.repo = repo;
            Mapper.CreateMap<SplitModel, Split>();
            Mapper.CreateMap<Split, SplitModel>()
                .ForMember(c => c.PersonName, option => option.Ignore())
                .ForMember(c => c.Commision, option => option.Ignore())
                .ForMember(c => c.DirversAmount, option => option.Ignore())
                .ForMember(c => c.Deposit, option => option.Ignore())
                .ForMember(c => c.Cash, option => option.Ignore());
            Mapper.CreateMap<ExtraModel, Extra>();
            Mapper.CreateMap<Extra, ExtraModel>();
            Initialize();
        }
        private void Initialize() {
            
            view.SaveSplit += OnSave;
            view.NewSplit += OnNew;
            view.PrevSplit += OnPrevious;
            view.NextSplit += OnNext;
            view.ModelChange += OnModelChange;
            people = repo.GetAllDrivers();
            view.People = people;
            //BlankSplit();
            GetAndMapCurrentSplitByMonth(DateTime.UtcNow, people.FirstOrDefault().Id);

            view.StatusChange = "Ready";

        }

        private void BlankSplit(int personId)
        {
            //Create a new blank 
            split = new SplitModel();
            split.PersonID = personId;

            split.StartDateUtc = DateTime.UtcNow;
            split.CreateDateUtc = DateTime.UtcNow;
            split.name = this.SplitNumber(split.StartDateUtc) + "-" + split.StartDateUtc.ToString("MMMM");
            MapModelToView();
        }


        void OnSave(object sender, EventArgs e)
        {
            this.repo.SaveSplit(Mapper.Map<Split>(this.split));
        }

        void OnNew(object sender, EventArgs e)
        {
            BlankSplit(view.PersonID);
        }

        void OnPrevious(object sender, EventArgs e)
        {
            GetAndMapPreviousSplitByMonth(view.StartDateUtc);
        }

        void OnNext(object sender, EventArgs e)
        {
            GetAndMapNextSplitByMonth(view.StartDateUtc);
        }

        private void GetAndMapPreviousSplitByMonth(DateTime date)
        {
            var splitDTO = this.GetPreviousSplitbyMonth(date);
            MapSplit(splitDTO);
        }

        private void GetAndMapNextSplitByMonth(DateTime date)
        {
            var splitDTO = this.GetNextSplitbyMonth(date);
            MapSplit(splitDTO);
        }

        private void GetAndMapCurrentSplitByMonth(DateTime date, int personId)
        {
            Split splitDTO = this.GetCurrentSplitbyMonth(date, personId);
            MapSplit(splitDTO);
        }

        private void MapSplit(Split splitDTO)
        {
            if (splitDTO != null)
            {
                split = Mapper.Map<SplitModel>(splitDTO);
                MapModelToView();
            }
            else
            {
                this.BlankSplit(people.First().Id);
            }
            //In case there is no split show a message
        }

        private void MapModelToView()
        {
            //Values from screen
            view.Total = split.Total;
            view.Toll = split.Toll;
            view.Credit = split.Credit;
            view.Expense = split.Expense;
            view.PersonID = split.PersonID;
            view.Extras = split.Extras;
            view.StartDateUtc = split.StartDateUtc;
            view.CreateDateUtc = split.CreateDateUtc;

            //Calculated values from model
            view.Commision = split.Commision;
            view.DriversAmount = split.DirversAmount;
            view.Deposit = split.Deposit;
            view.Cash = split.Cash;
            view.isDirty = false;
        }

        void OnModelChange(object sender, EventArgs e)
        {
            
            if (split.PersonID != view.PersonID)
            {
                GetAndMapCurrentSplitByMonth(DateTime.UtcNow, view.PersonID);
            }
            else
            {
                //Values from screen
                split.Total = view.Total;
                split.Toll = view.Toll;
                split.Credit = view.Credit;
                split.Expense = view.Expense;
                split.PersonID = view.PersonID;
                split.Extras = view.Extras;
                split.StartDateUtc = view.StartDateUtc;
                split.CreateDateUtc = view.CreateDateUtc;

                //Calculated values from model
                view.Commision = split.Commision;
                view.DriversAmount = split.DirversAmount;
                view.Deposit = split.Deposit;
                view.Cash = split.Cash;
            }

        }

        private int SplitNumber(DateTime date)
        {
            var retval = 1;
            if (date.Day >= 1 && date.Day <= 15)
                retval = 0;
            return retval;
        }

        private Split GetPreviousSplitbyMonth(DateTime date)
        {
            int month = 0, year = date.Year;
            var number = this.SplitNumber(date);
            if (number == 0)
            {
                month = date.Month - 1;
                number++;
            }
            else
            {
                month = date.Month;
                number--;
            }

            return GetSplitByMonth(split.PersonID, month, year, number);
        }

        private Split GetCurrentSplitbyMonth(DateTime date, int personId)
        {
            int month = date.Month, year = date.Year;
            var number = this.SplitNumber(date);

            return GetSplitByMonth(personId, month, year, number);
        }

        private Split GetNextSplitbyMonth(DateTime date)
        {
            int month = 0, year = date.Year;
            var number = this.SplitNumber(date);
            if (number == 0)
            {
                month = date.Month;
                number++;
            }
            else
            {
                month = date.Month + 1;
                number--;
            }

            return GetSplitByMonth(split.PersonID, month, year, number);
        }

        private Split GetSplitByMonth(int personId, int month, int year, int number)
        {
            var splitDTO = repo.GetAllSplitsByMonth(month, year).Where(x => x.Driver.Id == personId).OrderBy(x => x.StartDateUtc).ToList();
            if (splitDTO.Count > 1)
                return splitDTO.ElementAt(number);
            else
                return splitDTO.FirstOrDefault();
        }
    }
}
