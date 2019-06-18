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
    public class PRODUCTOSController : Controller
    {
        private VENTASEntities db = new VENTASEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            return View(db.PRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUCTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROVEEDOR,PRODUC,PRECIO,CATEGORIA,PRECIO_MIN,PRECIO_MAX")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROVEEDOR,PRODUC,PRECIO,CATEGORIA,PRECIO_MIN,PRECIO_MAX")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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
