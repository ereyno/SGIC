using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SGIC.Models
{
    public class Gasto
    {
        public decimal importe { get; set; }
        public DateTime fecha { get; set; }
        public decimal kilometros { get; set; }
        public TipoGasto tipo { get; set; }

    }
}
