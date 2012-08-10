using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Quincena
    {
        [Key]
        public int QuincenaID { get; set; }

        public int AutomovilID { get; set; }
        public Automovil automovil { get; set; }

        public string name { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal total { get; set; }
        public decimal totalChofer { get; set; }
        public decimal totalDuenio { get; set; }
        public decimal totalAgencia { get; set; }
        public bool isLiquidada { get; set; }

        public virtual ICollection<Gasto> gastos { get; set; }
        public virtual ICollection<Semana> semanas { get; set; }

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
