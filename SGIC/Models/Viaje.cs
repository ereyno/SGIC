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
        public int ViajeID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime fecha { get; set; }

        [Display(Name = "Numero de Viaje")]
        [Required(ErrorMessage = "El número de viaje es requerido.")]
        public int numeroViaje { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Monto Efectivo")]
        public decimal efectivo { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Monto Cta. Cte.")]
        public decimal importe { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Monto Peaje")]
        public decimal peaje { get; set; }

        //Navigation
        public virtual Dia dia { get; set; }

        //Reference
        //public int DiaID { get; set; }
    }
}