using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGIC.Models;
using SGIC.DAL;
using SGIC.ViewModel;

namespace SGIC.Controllers
{ 
    public class TelefonoController : Controller
    {
        private SGICContext db = new SGICContext();

        //
        // GET: /Telefono/

        public ViewResult Index()
        {
            var telefonos = db.Telefonos.Include(t => t.persona).Include(t => t.tipo);
            return View(telefonos.ToList());
        }

        //
        // GET: /Telefono/Details/5

        public ViewResult Details(int id)
        {
            Telefono telefono = db.Telefonos.Find(id);
            return View(telefono);
        }

        //
        // GET: /Telefono/Create

        public ActionResult Create()
        {
            ViewBag.PersonaID = new SelectList(db.Personas, "PersonaID", "nombre");
            ViewBag.TipoTelefonoID = new SelectList(db.TipoTelefonos, "TipoTelefonoID", "nombre");
            return View();
        } 

        //
        // POST: /Telefono/Create

        [HttpPost]
        public ActionResult Create(PersonaViewModel model)
        {
            var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();
            if (ModelState.IsValid)
            {
                model.nuevoTelefono.persona = db.Personas.Find(model.persona.PersonaID);
                model.nuevoTelefono.tipo = db.TipoTelefonos.Find(model.nuevoTelefono.TipoTelefonoID);
                db.Telefonos.Add(model.nuevoTelefono);
                db.SaveChanges();
                return RedirectToAction("Index","Customer");  
            }
            return RedirectToAction("Index", "Customer");
        }
        
        //
        // GET: /Telefono/Edit/5
 
        public ActionResult Edit(int id)
        {
            Telefono telefono = db.Telefonos.Find(id);
            return View(telefono);
        }

        //
        // POST: /Telefono/Edit/5

        [HttpPost]
        public ActionResult Edit(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefono);
        }

        //
        // GET: /Telefono/Delete/5
 
        public ActionResult Delete(int id)
        {
            Telefono telefono = db.Telefonos.Find(id);
            return View(telefono);
        }

        //
        // POST: /Telefono/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Telefono telefono = db.Telefonos.Find(id);
            db.Telefonos.Remove(telefono);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}