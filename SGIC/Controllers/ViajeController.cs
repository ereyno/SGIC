using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGIC.Models;

namespace SGIC.Controllers
{ 
    public class ViajeController : Controller
    {
        private SGICContext db = new SGICContext();

        //
        // GET: /Viaje/

        public ViewResult Index()
        {
            return View(db.Viajes.ToList());
        }

        //
        // GET: /Viaje/Details/5

        public ViewResult Details(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            return View(viaje);
        }

        //
        // GET: /Viaje/Create

        public ActionResult Create()
        {
            Viaje model = new Viaje();
            return View(model);
        } 

        //
        // POST: /Viaje/Create

        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Viajes.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(viaje);
        }
        
        //
        // GET: /Viaje/Edit/5
 
        public ActionResult Edit(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            return View(viaje);
        }

        //
        // POST: /Viaje/Edit/5

        [HttpPost]
        public ActionResult Edit(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        //
        // GET: /Viaje/Delete/5
 
        public ActionResult Delete(int id)
        {
            Viaje viaje = db.Viajes.Find(id);
            return View(viaje);
        }

        //
        // POST: /Viaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Viaje viaje = db.Viajes.Find(id);
            db.Viajes.Remove(viaje);
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