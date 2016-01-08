using Lost.Common;
using Lost.DAL;
using Lost.Model;
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
        
        protected ILostService LostService { get; private set; }
        protected IRedService RedService { get; private set; }

        #region Constructor
        public LostController(ILostService lostService, IRedService redService)
        {
            LostService = lostService;
            RedService = redService;
        }
        #endregion

        #region methods
        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var lp = await LostService.GetAllLostPersons(new Common.Filters.GenericFilter(searchString, pageNumber, pageSize));
            return View(lp);
        }


        public async Task<ActionResult> ReportMissing()
        {
            ViewBag.RedCross = await RedService.GetAllAsync(null);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReportMissing([Bind(Include="Id,FirstName,LastName,Birthday,City,Country,DateLastSeen,LocationLastSeen,ReporterName,ReportDate,Location,IsFound,RedCrossId")] LostPersonModel lpm)
        {
            if (ModelState.IsValid)
            {

                await LostService.ReportLostPerson(AutoMapper.Mapper.Map<LostPerson>(lpm));
                
                return RedirectToAction("Index");
            }
            ViewBag.RedCross = await RedService.GetAllAsync(null);

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
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.RedCross = await RedService.GetAllAsync(null);

            ILostPerson lostPerson = await LostService.FindByIdAsync(id);
            if (lostPerson == null)
                return HttpNotFound();

            return View(lostPerson);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Birthday,City,Country,DateLastSeen,LocationLastSeen,ReporterName,ReportDate,Location,IsFound,RedCrossId")] LostPersonModel lpm)
        {
            try
            {
                ViewBag.RedCross = await RedService.GetAllAsync(null);

                if (ModelState.IsValid)
                {
                    await LostService.UpdateLostPerson(AutoMapper.Mapper.Map<LostPerson>(lpm));
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Delete(Guid id) //must be nullable
        {
            //if (id == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var lostPersonToDelete = await LostService.FindByIdAsync(id);
            if (lostPersonToDelete == null)
                return HttpNotFound();

            return View(lostPersonToDelete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            await LostService.DeleteMissingPerson(id);
            return RedirectToAction("Index");
        }

    }
        #endregion
}
