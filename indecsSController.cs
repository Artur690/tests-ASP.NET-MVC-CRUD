using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class indecsSController : Controller
    {
        private indecsDBContext db = new indecsDBContext();

        // GET: indecsS
        public ActionResult Index(string searchString)
        {
            return View(db.indecsS.ToList());
        }

        // GET: indecsS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indecs indecs = db.indecsS.Find(id);
            if (indecs == null)
            {
                return HttpNotFound();
            }
            return View(indecs);
        }

        // GET: indecsS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indecsS/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImageUrl,Manufacturer,Year,Model,Price")] indecs indecs)
        {
            if (ModelState.IsValid)
            {
                db.indecsS.Add(indecs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indecs);
        }

        // GET: indecsS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indecs indecs = db.indecsS.Find(id);
            if (indecs == null)
            {
                return HttpNotFound();
            }
            return View(indecs);
        }

        // POST: indecsS/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImageUrl,Manufacturer,Year,Model,Price")] indecs indecs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indecs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indecs);
        }

        // GET: indecsS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indecs indecs = db.indecsS.Find(id);
            if (indecs == null)
            {
                return HttpNotFound();
            }
            return View(indecs);
        }

        // POST: indecsS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indecs indecs = db.indecsS.Find(id);
            db.indecsS.Remove(indecs);
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
