using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGIC.Models
{
    public class Dia
    {
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public List<Viaje> viajes { get; set; }

        #region

        public decimal LiquidarDia()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}