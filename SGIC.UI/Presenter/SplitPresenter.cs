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
        }
        private void Initialize() {
            split = new SplitModel();
            view.SaveSplit += OnSave;
            view.NewSplit += OnNew;
            view.PrevSplit += OnPrevious;
            view.NextSplit += OnNext;
            view.ModelChange += OnModelChange;
            view.People = repo.GetAllDrivers();
            view.Extras = split.Extras;
            BlankSplit();
            view.StatusChange = "Ready";
        }

        private void BlankSplit()
        {
            //Create a new blank 
            view.StartDateUtc = DateTime.UtcNow;
            view.CreateDateUtc = DateTime.UtcNow;
        }


        void OnSave(object sender, EventArgs e)
        {
            this.repo.SaveSplit(Mapper.Map<Split>(this.split));
        }

        void OnNew(object sender, EventArgs e)
        {
        }

        void OnPrevious(object sender, EventArgs e)
        {
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

            //Calculated values from model
            view.Commision = split.Commision;
            view.DriversAmount = split.DirversAmount;
            view.Deposit = split.Deposit;
            view.Cash = split.Cash;
        }
    }
}
