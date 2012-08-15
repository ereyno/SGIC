using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SGIC.Models;
using System.Data.Entity.Infrastructure;

namespace SGIC.DAL
{
    public class SGICInitializer : DropCreateDatabaseIfModelChanges<SGICContext>
    {
        protected override void Seed(SGICContext context)
        {
            var tipoTelefonos = new List<TipoTelefono> 
            { 
                new TipoTelefono { nombre = "Fijo" },
                new TipoTelefono { nombre = "Movil" },
                new TipoTelefono { nombre = "Radio" }
            };
            tipoTelefonos.ForEach(t => context.TipoTelefonos.Add(t));
            context.SaveChanges();
        }
    }
}