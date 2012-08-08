using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace SGIC.Models
{
    public class Persona
    {
        public string nombre { get; set; }
        public int dni { get; set; }
        public string direccion { get; set; }
        public List<Telefono> telefonos { get; set; }
        public List<Rol> roles { get; set; }
    }
}
