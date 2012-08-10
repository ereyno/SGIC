using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Automovil
    {
        [Key]
        public int AutomovilID { get; set; }

        public string patente { get; set; }
        public DateTime fechaInicio { get; set; }
        public Persona chofer { get; set; }
        public Persona duenio { get; set; }
        public string foto { get; set; }


        public virtual ICollection<Gasto> gastos { get; set; }
        public virtual ICollection<Quincena> quincenas { get; set; }

        #region

        public bool LiquidarQuincena() 
        {
            bool retval = false;
            return retval;
        }

        #endregion
    }
}
