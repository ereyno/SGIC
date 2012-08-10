using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Gasto
    {
        [Key]
        public int GastoID { get; set; }

        public int TipoGastoID { get; set; }
        public int? QuincenaID { get; set; }
        public int? AutomovilID { get; set; }
        public virtual Automovil automovil { get; set; }
        public virtual Quincena quincena { get; set; }

        public decimal importe { get; set; }
        public DateTime fecha { get; set; }
        public decimal kilometros { get; set; }

        public virtual TipoGasto tipo { get; set; }

    }
}
