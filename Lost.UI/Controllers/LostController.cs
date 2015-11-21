using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.Model.Common;
using Lost.Service.Common;
using Lost.DAL;
using Lost.DAL.Models;
using System.Net;
using System.Data;
using PagedList;
using System.Threading.Tasks;
using Lost.UI.Models;

namespace Lost.UI.Controllers
{
    public class LostController : Controller
    {
        #region Constructor
        private readonly ILostService LostService;

        public LostController(ILostService lostService)
        {
            LostService = lostService;
        }
        #endregion

        #region methods
        public async Task<ActionResult> Index()
        {
            try
            {
                var lostPersons = await LostService.GetAllLostPersons();
                return View(lostPersons);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReportMissing(LostPersonEntity lpm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await LostService.ReportLostPerson(AutoMapper.Mapper.Map<ILostPerson>(lpm));
                    return RedirectToAction("Index");
                }

                return View(lpm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> Details(int id)
        {
            //if (id == null)  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ILostPerson lp = await LostService.FindByIdAsync(id);

            if (lp == null) return HttpNotFound();

            return View(lp);
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                //if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var lp = await LostService.FindByIdAsync(id);

                if (lp == null) return HttpNotFound();

                return View(lp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int id)
        {
            try
            {
                if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var personToUpdate = LostService.FindByIdAsync(id);
                if (TryUpdateModel(personToUpdate))
                {
                    try
                    {
                        await LostService.UpdateLostPerson(AutoMapper.Mapper.Map<ILostPerson>(personToUpdate));
                        return RedirectToAction("Index");
                    }
                    catch (DataException /*x*/)
                    {
                        ModelState.AddModelError("", "Update failed");
                    }
                }
                return View(personToUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}