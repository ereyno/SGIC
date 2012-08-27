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
    public class AutomovilController : Controller
    {
        private SGICContext db = new SGICContext();

        //
        // GET: /Automovil/

        public ViewResult Index()
        {
            return View(db.Automoviles.ToList());
        }

        //
        // GET: /Automovil/Details/5

        public ViewResult Details(int id)
        {
            Automovil automovil = db.Automoviles.Find(id);
            return View(automovil);
        }

        //
        // GET: /Automovil/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Automovil/Create

        [HttpPost]
        public ActionResult Create(PersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Automoviles.Add(model.nuevoAutomovil);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(model.nuevoAutomovil);
        }
        
        //
        // GET: /Automovil/Edit/5
 
        public ActionResult Edit(int id)
        {
            Automovil automovil = db.Automoviles.Find(id);
            return View(automovil);
        }

        //
        // POST: /Automovil/Edit/5

        [HttpPost]
        public ActionResult Edit(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automovil);
        }

        //
        // GET: /Automovil/Delete/5
 
        public ActionResult Delete(int id)
        {
            Automovil automovil = db.Automoviles.Find(id);
            return View(automovil);
        }

        //
        // POST: /Automovil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Automovil automovil = db.Automoviles.Find(id);
            db.Automoviles.Remove(automovil);
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