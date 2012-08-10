using System;
using System.ComponentModel.DataAnnotations;

namespace SGIC.Models
{
    public class TipoGasto
    {
        [Key]
        public int TipoGastoID { get; set; }

        public string nombre { get; set; }
    }
}
