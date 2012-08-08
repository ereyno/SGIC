using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace SGIC
{
    public class Telefono
    {
        public string numero { get; set; }
        public bool isPrincipal { get; set; }
        public TipoTelefono tipo { get; set; }
    }
}
