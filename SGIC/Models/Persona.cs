using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public string direccion { get; set; }


        public virtual ICollection<Telefono> telefonos { get; set; }
        public virtual ICollection<Rol> roles { get; set; }
    }
}
