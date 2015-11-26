using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lost.Model.Common;
using Lost.Service.Common;
using Lost.WebAPI.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Lost.WebAPI.Controllers
{
    //[RoutePrefix("api/lost")]
    public class LostPersonController : ApiController
    {
        private readonly ILostService Service;

        public LostPersonController(ILostService service)
        {
            Service = service;
        }

        //result controllera treba biti HttpResponseMessage
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                IEnumerable<ILostPerson> ret = await Service.GetAllLostPersons();
                if (ret != null)
                {
                    //kreiranje response messagea ako je sve uredu
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<IEnumerable<LostPersonModel>>(ret));
                }
                else
                {
                    //kreiranje reposnse messagea ako nije pronadjen
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                //kreiranje reposnse messagea ako dode do greske
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
