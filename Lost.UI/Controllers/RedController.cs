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
using Lost.Common.Filters;
using Lost.UI.Models;
using Lost.Model;

namespace Lost.UI.Controllers
{
    public class RedController : Controller
    {
        private readonly IRedService Service;

        public RedController(IRedService service)
        {
            Service = service;
        }

        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var rc = await Service.GetAllAsync(new GenericFilter(searchString, pageNumber, pageSize));
            return View(rc);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RedCrossModel rcm)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<RedCross>(rcm));

                return RedirectToAction("Index");
            }
            return View(rcm);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var rcToDelete = await Service.GetByIdAsync(id);
            if (rcToDelete == null)
                return HttpNotFound();

            return View(rcToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRedCross(Guid id)
        {
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}