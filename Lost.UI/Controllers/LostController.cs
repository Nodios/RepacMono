using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.Model.Common;
using Lost.Service.Common;

namespace Lost.UI.Controllers
{
    public class LostController : Controller
    {
        #region Constructor
        public LostController(ILostService service)
        {
            this.Service = service;
        }
        #endregion
        #region Properties
        protected ILostService Service { get; private set; }
        #endregion

        #region Methods
        // GET: Lost
        public ActionResult Index()
        {
            var lostPersons = Service.GetAllMissingPersons();
            return View(lostPersons);
        }
        #endregion
    }
}