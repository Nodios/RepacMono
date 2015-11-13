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

namespace Lost.UI.Controllers
{
    public class RedController : Controller
    {
        #region Constructor
        protected IRedService Service { get; private set; }

        public RedController(IRedService redService)
        {
            this.Service = redService;
        }
        #endregion

        // GET: Red
        public ActionResult Index(string sortOrder, string locationString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";

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

            var redCross = Service.GetAll();


            if (!String.IsNullOrEmpty(locationString))
            {
                redCross = Service.GetByCountry(locationString);
            }

            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    redCross = redCross.OrderByDescending(s => s.Name);
                    break;
                case "City":
                    redCross = redCross.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    redCross = redCross.OrderByDescending(s => s.City);
                    break;
                default:
                    redCross = redCross.OrderBy(s => s.Name);
                    break;
            }

            //Change pageSize to change amount of displayed rows in table
            int pageSize = 5;

            //if left-hand operand is not null, return left, otherwise return right
            //a.k.a. direct IF
            int pageNumber = (page ?? 1);

            return View(redCross.ToPagedList(pageNumber, pageSize));
        }
    }
}