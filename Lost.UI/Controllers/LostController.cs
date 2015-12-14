using Lost.Common;
using Lost.DAL;
using Lost.Model.Common;
using Lost.Service.Common;
using Lost.UI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lost.UI.Controllers
{
    public class LostController : Controller
    {
        #region Constructor
        protected ILostService LostService { get; private set; }
        protected IRedService RedService { get; private set; }

        public LostController(ILostService lostService, IRedService redService)
        {
            LostService = lostService;
            RedService = redService;
        }
        #endregion

        #region methods
        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var lp = await LostService.GetAllLostPersons(new Common.Filters.LostPersonFilter(searchString, pageNumber, pageSize));
            return View(lp);
        }
        public async Task<ActionResult> ReportMissing()
        {
            ViewBag.RedCross = new SelectList(await RedService.GetAllAsync(), "RedCrossId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReportMissing([Bind(Include="FirstName,LastName,Birthday,City,Country,DateLastSeen,LocationLastSeen,ReporterName,ReportDate,Location,IsFound,RedCrossId")] LostPersonModel lpm)
        {
            if (ModelState.IsValid)
            {
                await LostService.ReportLostPerson(AutoMapper.Mapper.Map<ILostPerson>(lpm));
                return RedirectToAction("Index");
            }
            ViewBag.RedCross = new SelectList(await RedService.GetAllAsync(), "RedCrossId", "Name");
            return View(lpm);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                if (id == null) 
                { 
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ILostPerson lp = await LostService.FindByIdAsync(id);

                if (lp == null)
                    return HttpNotFound();

                return View(lp);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                ILostPerson lp = await LostService.FindByIdAsync(id);
                if (lp == null)
                    return HttpNotFound();

                return View(lp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(Guid id, LostPersonModel model)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                int ret = await LostService.UpdateLostPerson(AutoMapper.Mapper.Map<ILostPerson>(model));

                if (ret >= 1)
                    return View(ret);
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                //ILostPerson personToUpdate = await LostService.FindByIdAsync(id);
                //if (TryUpdateModel(personToUpdate))
                //{
                //    try
                //    {
                //        await LostService.UpdateLostPerson(AutoMapper.Mapper.Map<ILostPerson>(personToUpdate));
                //        return RedirectToAction("Index");
                //    }
                //    catch (DataException e)
                //    {
                //        ModelState.AddModelError("GRESKA!", e);
                //    }
                //}
                //return View(personToUpdate);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}