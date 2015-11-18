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
        #endregion
    }
}