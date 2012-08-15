using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public abstract class Rol
    {
        [Key]
        public int RolID { get; set; }

        //Navigation
        public virtual Persona persona { get; set; }

        //reference
        //public int PersonaID { get; set; }
    }
}
