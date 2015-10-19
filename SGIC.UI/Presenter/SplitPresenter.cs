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

        public SplitPresenter(ISplitView view, ISplitRepository repo)
        {
            this.view = view;
            this.repo = repo;
            Initialize();
            Mapper.CreateMap<SplitModel, Split>();
            Mapper.CreateMap<Split, SplitModel>();
            Mapper.CreateMap<ExtraModel, Extra>();
            Mapper.CreateMap<Extra, ExtraModel>();
        }
        private void Initialize() {
            
            view.SaveSplit += OnSave;
            view.NewSplit += OnNew;
            view.PrevSplit += OnPrevious;
            view.NextSplit += OnNext;
            view.ModelChange += OnModelChange;

            BlankSplit();
            view.StatusChange = "Ready";
        }

        private void BlankSplit()
        {
            var people = repo.GetAllDrivers();
            //Create a new blank 
            split = new SplitModel();
            split.name = view.StartDateUtc.ToString("MMM");
            split.PersonID = people.First().Id;

            view.StartDateUtc = DateTime.UtcNow;
            view.CreateDateUtc = DateTime.UtcNow;
            view.People = people;
            view.Extras = split.Extras;
            view.Total = 0;
            view.Toll = 0;
            view.Credit = 0;
            view.Expense = 0;
            view.PersonID = split.PersonID;
            view.Extras = split.Extras;
        }


        void OnSave(object sender, EventArgs e)
        {
            this.repo.SaveSplit(Mapper.Map<Split>(this.split));
        }

        void OnNew(object sender, EventArgs e)
        {
            BlankSplit();
        }

        void OnPrevious(object sender, EventArgs e)
        {
            var month = view.StartDateUtc.Month - 1;
            var year = view.StartDateUtc.Year;
            var splitDTO = repo.GetAllSplitsByMonth(month, year).OrderByDescending(x => x.StartDateUtc).FirstOrDefault();
            if(splitDTO != null)
            {
                split = Mapper.Map<SplitModel>(splitDTO);
                //Values from screen
                view.Total = split.Total;
                view.Toll = split.Toll;
                view.Credit = split.Credit;
                view.Expense = split.Expense;
                view.PersonID = split.PersonID;
                view.Extras = split.Extras;
                view.StartDateUtc = split.StartDateUtc;

                //Calculated values from model
                view.Commision = split.Commision;
                view.DriversAmount = split.DirversAmount;
                view.Deposit = split.Deposit;
                view.Cash = split.Cash;
            }
        }

        void OnNext(object sender, EventArgs e)
        {
        }

        void OnModelChange(object sender, EventArgs e)
        {
            //Values from screen
            split.Total = view.Total;
            split.Toll = view.Toll;
            split.Credit = view.Credit;
            split.Expense = view.Expense;
            split.PersonID = view.PersonID;
            split.Extras = view.Extras;
            split.StartDateUtc = view.StartDateUtc;

            //Calculated values from model
            view.Commision = split.Commision;
            view.DriversAmount = split.DirversAmount;
            view.Deposit = split.Deposit;
            view.Cash = split.Cash;
        }
    }
}
