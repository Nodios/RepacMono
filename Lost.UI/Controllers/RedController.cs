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

namespace Lost.UI.Controllers
{
    public class RedController : Controller
    {
        private readonly IRedService Service;

        public RedController(IRedService service)
        {
            Service = service;
        }

        public async Task<ActionResult> Index(int? page)
        {
            //Variables for paging
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            try
            {
                var redCross = await Service.GetAllAsync();
                return View(redCross.ToPagedList(pageNumber, pageSize));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}