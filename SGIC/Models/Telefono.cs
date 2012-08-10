using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class Telefono
    {
        [Key]
        public int TelefonoID { get; set; }

        public int TipoTelefonoID { get; set; }
        public int PersonaID { get; set; }
        public virtual Persona persona { get; set; }

        [Display(Name = "Codigo Area")]
        [MaxLength(5)]
        public string codigoArea { get; set; }

        [Display(Name = "Número de telefono")]
        [MaxLength(6)]
        public string primerParte { get; set; }

        [MaxLength(6)]
        public string segundaParte{ get; set; }

        [Display(Name = "Es principal?")]
        public bool isPrincipal { get; set; }

        [Display(Name = "Tipo")]
        public virtual TipoTelefono tipo { get; set; }
    }
}
