using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.Domain.Entities
{
    public class Split
    {
        public int Id { get; set; }

        public string name { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public decimal Total { get; set; }
        public decimal Expense { get; set; }
        public decimal Credit { get; set; }
        public decimal Toll { get; set; }

        public decimal Commision { get; }
        public decimal DirversAmount { get; }
        public decimal Deposit { get; }
        public int PersonID { get; set; }
        public bool isReady { get; set; }

        //Navegation Properties
        public virtual ICollection<Extra> Extras { get; set; }
        public virtual Person Driver { get; set; }


        #region

        public bool LiquidarQuincena()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularGastos()
        {
            throw new NotImplementedException();
        }

        public int CalcularDiasSinTrabajar()
        {
            throw new NotImplementedException();
        }

        private decimal CalcularComision()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
