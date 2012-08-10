using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Dia
    {
        [Key]
        public int DiaID { get; set; }

        public int SemanaID { get; set; }
        public virtual Semana semana { get; set; }

        public DateTime fecha { get; set; }
        public decimal total { get; set; }

        public virtual ICollection<Viaje> viajes { get; set; }

        #region

        public decimal LiquidarDia()
        {
            throw new NotImplementedException();
        }

        public bool CalcularTotalParcial()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}