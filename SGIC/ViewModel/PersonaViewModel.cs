using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGIC.Models;

namespace SGIC.ViewModel
{
    public class PersonaViewModel
    {
        public Persona persona { get; set; }
        public Telefono nuevoTelefono { get; set; }
        public Automovil nuevoAutomovil { get; set; }
        public List<Automovil> vehiculos { get; set; }
    }
}