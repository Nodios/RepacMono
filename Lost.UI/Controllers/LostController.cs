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
using PagedList;
using System.Threading.Tasks;
using Lost.UI.Models;
using Lost.Common;

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
        public async Task<ActionResult> Index(int? page/*, Guid redCrossId*/)
        {
            //Variables
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            try
            {
                //if(redCrossId != null)
                //{
                //    var lostPersons = await LostService.GetFromRedCross(redCrossId);
                //    return View(lostPersons.ToPagedList(pageNumber, pageSize));
                //}
                //else
                //{
                //    var lostPersons = await LostService.GetAllLostPersons();
                //    return View(lostPersons.ToPagedList(pageNumber, pageSize));
                //}


                var lostPersons = await LostService.GetAllLostPersons();
                return View(lostPersons.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ReportMissing()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReportMissing(LostPersonModel lpm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int ret = await LostService.ReportLostPerson(AutoMapper.Mapper.Map<ILostPerson>(lpm));
                    return RedirectToAction("Index");
                }

                return View(lpm);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}