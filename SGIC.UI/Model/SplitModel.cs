using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.UI.Model
{
    public class SplitModel
    {
        public SplitModel()
        {
            this.Extras = new List<ExtraModel>();
        }
        public int Id { get; set; }

        public string name { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public decimal Total { get; set; }
        public decimal Expense { get; set; }
        public decimal Credit { get; set; }
        public decimal Toll { get; set; }
        public decimal Commision 
        { 
            get 
            {
                return ((this.Total * 20) / 100);
            } 
        }
        public decimal DirversAmount 
        { 
            get 
            {
                return ((((this.Total - this.Commision) - (this.Expense / 2)) / 2) - (this.Total - this.Credit)) - this.Extras.Sum(x => x.Value);
            } 
        }
        public decimal Deposit
        {
            get
            {
                return (this.Credit + this.Toll - this.Commision);
            }
        }
        public decimal Cash 
        {
            get
            {
                return (this.Total - this.Credit);
            }
        }
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public bool isReady { get; set; }
        public List<ExtraModel> Extras { get; set; }
    }

    public class ExtraModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public decimal Value { get; set; }
        public string ShowValue 
        {
            get
            {
                return this.Key + ": " + this.Value.ToString("c");
            }
        }
    }
}
