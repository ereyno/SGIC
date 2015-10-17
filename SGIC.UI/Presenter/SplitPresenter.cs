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
        private readonly ISplitView view;
        private SplitModel split;
        // (primitive) maintenance of state:
        private int currentIndex = 0;
        private bool isNew = true;

        public SplitPresenter(ISplitView view)
        {
            this.view = view;
            Initialize();
        }
        private void Initialize() {
            split = new SplitModel();
            view.SaveSplit += OnSave;
            view.NewSplit += OnNew;
            view.PrevSplit += OnPrevious;
            view.NextSplit += OnNext;
            BlankSplit();
            view.StatusChange = "Ready";
        }

        private void BlankSplit()
        {
            //Create a new blank 
        }


        void OnSave(object sender, EventArgs e)
        { 
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
            split.Toll = view.Total;
            split.Credit = view.Credit;
            split.Expense = view.Expense;

            //Calculated values from model
            view.Commision = split.Commision;
            view.DirversAmount = split.DirversAmount;
            view.Deposit = split.Deposit;
        }
    }
}
