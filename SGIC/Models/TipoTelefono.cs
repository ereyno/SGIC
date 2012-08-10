using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class TipoTelefono
    {
        [Key]
        public int TipoTelefonoID { get; set; }

        public string nombre { get; set; }
    }
}
