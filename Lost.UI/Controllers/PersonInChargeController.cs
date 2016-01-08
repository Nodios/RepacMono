using Lost.Model.Common;
using Lost.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lost.UI.Controllers
{
    public class PersonInChargeController : Controller
    {
        protected IPersonInChargeService Service { get; private set; }

        public PersonInChargeController(IPersonInChargeService service)
        {
            Service = service;
        }

        // GET: PersonInCharge
        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var pic = await Service.GetAsync(new Common.Filters.GenericFilter(searchString, pageNumber, pageSize));
            return View(pic);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            IPersonInCharge pic = await Service.GetAsync(id);

            if (pic == null) return HttpNotFound();

            return View(pic);
        }

        public async Task<ActionResult> Edit(IPersonInCharge personInCharge)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<IPersonInCharge>(personInCharge));
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}