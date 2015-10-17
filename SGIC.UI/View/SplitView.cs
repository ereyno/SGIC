using SGIC.UI.Abstract;
using SGIC.UI.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGIC.UI.View
{
    public partial class SplitView : Form, ISplitView
    {
        private SplitPresenter presenter = null;
        public SplitView()
        {
            InitializeComponent();
        }

        public int Id { get; set; }

        public string name { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public decimal Total { get; set; }

        public decimal Expense { get; set; }

        public decimal Credit { get; set; }

        public decimal Toll { get; set; }

        public int PersonID { get; set; }

        public bool isReady { get; set; }

        public string StatusChange { get; set; }

        public bool isDirty { get; set; }
        public decimal Commision { get; set; }
        public decimal DirversAmount { get; set; }
        public decimal Deposit { get; set; }

        public event EventHandler<EventArgs> SaveSplit;

        public event EventHandler<EventArgs> NewSplit;

        public event EventHandler<EventArgs> PrevSplit;

        public event EventHandler<EventArgs> NextSplit;

        public event EventHandler<EventArgs> ModelChange;

        private void SplitView_Load(object sender, EventArgs e)
        {
            presenter = new SplitPresenter(this);
            this.isDirty = true;
        }
    }
}
