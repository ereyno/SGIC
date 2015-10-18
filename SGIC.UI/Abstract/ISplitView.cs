using SGIC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.UI.Abstract
{
    public interface ISplitView
    {
        int Id { get; set; }

        string name { get; set; }
        DateTime StartDateUtc { get; set; }
        DateTime CreateDateUtc { get; set; }
        decimal Total { get; set; }
        decimal Expense { get; set; }
        decimal Credit { get; set; }
        decimal Toll { get; set; }
        int PersonID { get; set; }
        bool isReady { get; set; }
        decimal Commision { get; set; }
        decimal DriversAmount { get; set; }
        decimal Deposit { get; set; }
        decimal Cash { get; set; }
        string StatusChange { set; }
        bool isDirty { get; set; }
        List<Person> People { get; set; }
        event EventHandler<EventArgs> SaveSplit;
        event EventHandler<EventArgs> NewSplit;
        event EventHandler<EventArgs> PrevSplit;
        event EventHandler<EventArgs> NextSplit;
        event EventHandler<EventArgs> ModelChange;
    }
}
