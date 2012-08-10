using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Semana
    {
        [Key]
        public int SemanaID { get; set; }

        public int QuincenaID { get; set; }
        public virtual Quincena quincena { get; set; }

        public decimal totalEfectivo { get; set; }
        public decimal totalCuentaCorriente { get; set; }
        public decimal totalPeajesPositivos { get; set; }
        public decimal totalPeajesNegativos { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal totalEstacionamientos { get; set; }

        public virtual ICollection<Dia> dias { get; set; }

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
