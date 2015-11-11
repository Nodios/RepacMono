﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.Model.Common;
using Lost.Service.Common;
using Lost.DAL;
using System.Net;
using System.Data;
using PagedList;

namespace Lost.UI.Controllers
{
    public class LostController : Controller
    {
        #region Constructor
        ILostService lostService;

        public LostController(ILostService lostService)
        {
            this.lostService = lostService;
        }
        #endregion

        #region Methods
        //TODO: Implement more search options.
        public ActionResult Index(string sortOrder, string locationString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateLsSortParm = sortOrder == "DateLs" ? "dateLs_desc" : "DateLs";

            //Paging
            if (locationString != null)
            {
                page = 1;
            }
            else
            {
                locationString = currentFilter;
            }
            ViewBag.CurrentFilter = locationString;

            var lostPersons = lostService.GetAll();


            if (!String.IsNullOrEmpty(locationString))
            {
                lostPersons = lostPersons.Where(l => l.LocationLastSeen.ToLower().Contains(locationString.ToLower()));
            }

            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    lostPersons = lostPersons.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    lostPersons = lostPersons.OrderBy(s => s.ReportDate);
                    break;
                case "date_desc":
                    lostPersons = lostPersons.OrderByDescending(s => s.ReportDate);
                    break;
                case "DateLs":
                    lostPersons = lostPersons.OrderBy(s => s.DateLastSeen);
                    break;
                case "dateLs_desc":
                    lostPersons = lostPersons.OrderByDescending(s => s.DateLastSeen);
                    break;
                default:
                    lostPersons = lostPersons.OrderBy(s => s.LastName);
                    break;
            }

            //Change pageSize to change amount of displayed rows in table
            int pageSize = 5;

            //if left-hand operand is not null, return left, otherwise return right
            //a.k.a. direct IF
            int pageNumber = (page ?? 1);

            return View(lostPersons.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ReportMissing()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportMissing(ILostPerson lpe)
        {
            if (ModelState.IsValid)
            {
                lostService.Create(lpe);
                return RedirectToAction("Index");
            }

            return View(lpe);
        }
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ILostPerson lp = lostService.GetById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ILostPerson lp = lostService.GetById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personToUpdate = lostService.GetById(id);
            if (TryUpdateModel(personToUpdate))
            {
                try
                {
                    lostService.Update(personToUpdate);
                    return RedirectToAction("Index");
                }
                catch(DataException /*dex*/)
                {
                    ModelState.AddModelError("", "nesto");
                }
            }
            return View(personToUpdate);
        }

        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ILostPerson lp = lostService.GetById(id);
            if (lp == null)
            {
                return HttpNotFound();
            }
            return View(lp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            ILostPerson lp = lostService.GetById(id);
            try
            {
                lostService.Delete(lp);
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