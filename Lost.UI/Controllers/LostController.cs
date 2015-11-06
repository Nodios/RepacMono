using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.Model.Common;
using Lost.Service.Common;
using Lost.DAL;
using System.Net;
using System.Data;

namespace Lost.UI.Controllers
{
    public class LostController : Controller
    {
        #region Constructor
        public LostController(ILostService service)
        {
            this.Service = service;
        }
        protected ILostService Service { get; private set; }
        #endregion

        #region Methods
        public ActionResult Index(string searchString, string locationString)
        {
            var lostPersons = Service.GetAllMissingPersons();

            if (!String.IsNullOrEmpty(searchString))
            {
                lostPersons = lostPersons.Where(l => l.FirstName.Contains(searchString) || l.LastName.Contains(searchString));
            }
            else if (!String.IsNullOrEmpty(locationString))
            {
                lostPersons = lostPersons.Where(l => l.Location.Contains(locationString));
            }

            return View(lostPersons);
        }
        public ActionResult ReportMissing()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportMissing(LostPersonEntity lpe)
        {
            if (ModelState.IsValid)
            {
                Service.ReportMissingPerson(lpe);
                Service.SaveMissingPerson();
                return RedirectToAction("Index");
            }

            return View(lpe);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lp = Service.GetMissingPersonById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lp = Service.GetMissingPersonById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personToUpdate = Service.GetMissingPersonById(id);
            if (TryUpdateModel(personToUpdate))
            {
                try
                {
                    Service.UpdateMissingPerson(personToUpdate);
                    Service.SaveMissingPerson();
                    return RedirectToAction("Index");
                }
                catch(DataException /*dex*/)
                {
                    ModelState.AddModelError("", "nesto");
                }
            }
            return View(personToUpdate);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostPersonEntity lp = Service.GetMissingPersonById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Service.DeleteMissingPerson(id);
                Service.SaveMissingPerson();
            }
            catch (DataException /*dex*/)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion
    }
}