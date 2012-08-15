using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Gasto
    {
        [Key]
        public int GastoID { get; set; }

        public decimal importe { get; set; }
        public DateTime fecha { get; set; }
        public decimal kilometros { get; set; }

        //Navigation
        public virtual Quincena quincena { get; set; }
        public virtual TipoGasto tipo { get; set; }
        public virtual Automovil automovil { get; set; }

        //Reference
        //public int QuincenaID { get; set; }
        //public int AutomovilID { get; set; }
        //public int TipoGastoID { get; set; }

    }
}
