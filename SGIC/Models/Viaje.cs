using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Viaje
    {
        public Viaje()
        {
            fecha = DateTime.Today;
        }
        [Key]
        public int id { get; set; }
        public DateTime fecha { get; set; }
        [Display(Name = "Numero de Viaje")]
        public int numeroViaje { get; set; }
        [Display(Name = "Monto Efectivo")]
        public decimal efectivo { get; set; }
        [Display(Name = "Monto Cta. Cte.")]
        public decimal importe { get; set; }
        [Display(Name = "Monto Peaje")]
        public decimal peaje { get; set; }
    }
}