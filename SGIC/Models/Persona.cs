using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Persona
    {
        public Persona()
        {
            if(telefonos == null)
                telefonos = new List<Telefono>();
            if(roles == null)
                roles = new List<IRol>();
        }

        [Key]
        public int PersonaID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string nombre { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "El DNI es requerido.")]
        public int dni { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es requerida.")]
        public string direccion { get; set; }


        public virtual ICollection<Telefono> telefonos { get; set; }
        public virtual ICollection<IRol> roles { get; set; }

        public bool LiquidarQuincena()
        {
            throw new NotImplementedException();
        }
    }
}
