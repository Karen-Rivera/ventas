using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentasK.Models;

namespace VentasK.Controllers
{
    public class DATOSController : Controller
    {
        private VENTASEntities db = new VENTASEntities();

        // GET: DATOS
        public ActionResult Index()
        {
            var dATOS = db.DATOS.Include(d => d.PRODUCTOS);
            return View(dATOS.ToList());
        }

        // GET: DATOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS dATOS = db.DATOS.Find(id);
            if (dATOS == null)
            {
                return HttpNotFound();
            }
            return View(dATOS);
        }

        // GET: DATOS/Create
        public ActionResult Create()
        {
            ViewBag.NOMBRE_PROVEEDOR = new SelectList(db.PRODUCTOS, "PROVEEDOR", "PRODUC");
            return View();
        }

        // POST: DATOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_PROVEEDOR,TELEFONO,FECHA_VENTA")] DATOS dATOS)
        {
            if (ModelState.IsValid)
            {
                db.DATOS.Add(dATOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NOMBRE_PROVEEDOR = new SelectList(db.PRODUCTOS, "PROVEEDOR", "PRODUC", dATOS.NOMBRE_PROVEEDOR);
            return View(dATOS);
        }

        // GET: DATOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS dATOS = db.DATOS.Find(id);
            if (dATOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.NOMBRE_PROVEEDOR = new SelectList(db.PRODUCTOS, "PROVEEDOR", "PRODUC", dATOS.NOMBRE_PROVEEDOR);
            return View(dATOS);
        }

        // POST: DATOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_PROVEEDOR,TELEFONO,FECHA_VENTA")] DATOS dATOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NOMBRE_PROVEEDOR = new SelectList(db.PRODUCTOS, "PROVEEDOR", "PRODUCTO", dATOS.NOMBRE_PROVEEDOR);
            return View(dATOS);
        }

        // GET: DATOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS dATOS = db.DATOS.Find(id);
            if (dATOS == null)
            {
                return HttpNotFound();
            }
            return View(dATOS);
        }

        // POST: DATOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DATOS dATOS = db.DATOS.Find(id);
            db.DATOS.Remove(dATOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
