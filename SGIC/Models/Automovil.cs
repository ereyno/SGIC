using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace SGIC.Models
{
    public class Automovil
    {
        public string patente { get; set; }
        public DateTime fechaInicio { get; set; }
        public Persona chofer { get; set; }
        public Persona duenio { get; set; }
        public string foto { get; set; }
        public List<Gasto> gastos { get; set; }
        public List<Quincena> quincenas { get; set; }

        #region

        public bool LiquidarQuincena() 
        {
            bool retval = false;
            return retval;
        }

        #endregion
    }
}
