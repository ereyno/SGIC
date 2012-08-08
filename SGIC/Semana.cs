using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SGIC
{
    public class Semana
    {
        public decimal totalEfectivo { get; set; }
        public decimal totalCuentaCorriente { get; set; }
        public decimal totalPeajesPositivos { get; set; }
        public decimal totalPeajesNegativos { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal totalEstacionamientos { get; set; }

        #region

        public decimal LiquidarSemana()
        {
            throw new NotImplementedException();
        }

        private decimal CalcularGastos()
        {
            throw new NotImplementedException();
        }

        private decimal CalcularIngresos()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
