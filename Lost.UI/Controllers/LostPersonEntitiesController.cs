using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lost.DAL;

namespace Lost.UI.Controllers
{
    public class LostPersonEntitiesController : Controller
    {
        private SearchContext db = new SearchContext();

        // GET: LostPersonEntities
        public ActionResult Index()
        {
            return View(db.LostPersons.ToList());
        }

        // GET: LostPersonEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lostPersonEntity = db.LostPersons.Find(id);
            if (lostPersonEntity == null)
            {
                return HttpNotFound();
            }
            return View(lostPersonEntity);
        }

        // GET: LostPersonEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LostPersonEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Birthday,City,Country,DateLastSeen,LocationLastSeen,ReporterName,ReportDate,Location,IsFound,RedCrossId")] LostPersonEntity lostPersonEntity)
        {
            if (ModelState.IsValid)
            {
                db.LostPersons.Add(lostPersonEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lostPersonEntity);
        }

        // GET: LostPersonEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lostPersonEntity = db.LostPersons.Find(id);
            if (lostPersonEntity == null)
            {
                return HttpNotFound();
            }
            return View(lostPersonEntity);
        }

        // POST: LostPersonEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Birthday,City,Country,DateLastSeen,LocationLastSeen,ReporterName,ReportDate,Location,IsFound,RedCrossId")] LostPersonEntity lostPersonEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostPersonEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lostPersonEntity);
        }

        // GET: LostPersonEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lostPersonEntity = db.LostPersons.Find(id);
            if (lostPersonEntity == null)
            {
                return HttpNotFound();
            }
            return View(lostPersonEntity);
        }

        // POST: LostPersonEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LostPersonEntity lostPersonEntity = db.LostPersons.Find(id);
            db.LostPersons.Remove(lostPersonEntity);
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
