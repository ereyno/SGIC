using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGIC.Models;
using SGIC.DAL;

namespace SGIC.Controllers
{ 
    public class CustomerController : Controller
    {
        private SGICContext db = new SGICContext();

        //
        // GET: /Customer/

        public ViewResult Index()
        {
            return View(db.Personas.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ViewResult Details(int id)
        {
            Persona persona = db.Personas.Find(id);
            return View(persona);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            ViewBag.TipoTelefonos = new SelectList(db.TipoTelefonos, "TipoTelefonoID", "nombre");
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(persona);
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Persona persona = db.Personas.Find(id);
            return View(persona);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Persona persona = db.Personas.Find(id);
            return View(persona);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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