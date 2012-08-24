using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class TipoTelefono
    {
        public TipoTelefono()
        { 
        }

        [Key]
        public int TipoTelefonoID { get; set; }
        [Display(Name = "Tipo")]
        public string nombre { get; set; }
    }
}
