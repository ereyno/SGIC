using SGIC.Domain.Entities;
using SGIC.UI.Abstract;
using SGIC.UI.Model;
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
        public decimal DriversAmount { get; set; }
        public decimal Deposit { get; set; }
        public decimal Cash { get; set; }
        public List<Person> People { get; set; }
        public List<ExtraModel> Extras { get; set; }
        public event EventHandler<EventArgs> SaveSplit;

        public event EventHandler<EventArgs> NewSplit;

        public event EventHandler<EventArgs> PrevSplit;

        public event EventHandler<EventArgs> NextSplit;

        public event EventHandler<EventArgs> ModelChange;

        private void SplitView_Load(object sender, EventArgs e)
        {
            this.isDirty = true;
            //Driver option
            this.cmbDriver.DataSource = this.People;
            this.cmbDriver.DisplayMember = "Name";
            this.cmbDriver.ValueMember = "Id";
            this.cmbDriver.Refresh();
            //Extras list            
            this.lstExtras.DisplayMember = "ShowValue";
            this.lstExtras.ValueMember = "Key";
            this.lstExtras.DataSource = this.Extras;
            this.lstExtras.Refresh();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            decimal.TryParse(txtTotal.Text, out value);
            this.Total = value;
            this.isDirty = true;
            ManageUpdate();
        }

        private void txtExpenses_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            decimal.TryParse(txtExpenses.Text, out value);
            this.Expense = value;
            ManageUpdate();
        }

        private void txtToll_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            decimal.TryParse(txtToll.Text, out value);
            this.Toll = value;
            ManageUpdate();
        }

        private void txtCredit_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            decimal.TryParse(txtCredit.Text, out value);
            this.Credit = value;
            ManageUpdate();
        }

        private void ManageUpdate()
        {
            this.isDirty = true;
            if (ModelChange != null)
            {
                ModelChange(this, EventArgs.Empty);
                this.UpdateReadOnly();
            }
        }

        private void UpdateReadOnly()
        {
            this.txtDriver.Text = this.DriversAmount.ToString("c");
            this.txtCommision.Text = this.Commision.ToString("c");
            this.txtDeposit.Text = this.Deposit.ToString("c");
            this.txtEfvo.Text = this.Cash.ToString("c");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveSplit(this, EventArgs.Empty);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = 0;
            int.TryParse(((ComboBox)sender).SelectedValue.ToString(), out id);
            this.PersonID = id;
            ManageUpdate();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            decimal.TryParse(this.txtExtraValue.Text, out value);
            var item = new ExtraModel { Key = this.txtExtra.Text, Value = value};
            this.Extras.Add(item);
            UpdateExtra();
            ManageUpdate();
            this.txtExtra.Text = string.Empty;
            this.txtExtraValue.Text = string.Empty;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstExtras.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un extra para borrar", "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var toremove = this.Extras.FirstOrDefault(x => x.Key == ((ExtraModel)this.lstExtras.SelectedItem).Key);
            this.Extras.Remove(toremove);
            UpdateExtra();
            ManageUpdate();
        }

        private void UpdateExtra()
        {
            this.lstExtras.DataSource = null;
            this.lstExtras.DisplayMember = "ShowValue";
            this.lstExtras.DataSource = this.Extras;
            this.lstExtras.Refresh();
        }
    }
}
