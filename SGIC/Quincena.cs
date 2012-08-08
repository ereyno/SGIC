using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace SGIC
{
    public class Quincena
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal total { get; set; }
        public List<Gasto> gastos { get; set; }
        public List<Semana> semanas { get; set; }
        public bool isLiquidada { get; set; }

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
