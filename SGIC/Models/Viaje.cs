using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGIC.Models
{
    public class Viaje
    {
        public DateTime fecha { get; set; }
        public int numeroViaje { get; set; }
        public decimal efectivo { get; set; }
        public decimal importe { get; set; }
        public decimal peaje { get; set; }
    }
}