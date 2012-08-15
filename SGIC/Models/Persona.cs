using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Persona
    {
        public Persona()
        {
            telefonos = new List<Telefono>();
            roles = new List<Rol>();
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
        public virtual ICollection<Rol> roles { get; set; }
    }
}
