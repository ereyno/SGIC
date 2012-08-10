using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public abstract class Rol
    {
        [Key]
        public int RolID { get; set; }

        public int PersonaID { get; set; }
        public virtual Persona persona { get; set; }
    }
}
