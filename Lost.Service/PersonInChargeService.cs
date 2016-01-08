using Lost.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Service
{
    public class PersonInChargeService : IPersonInChargeService
    {
        protected IPersonInChargeService Service { get; private set; }

        public PersonInChargeService(IPersonInChargeService service)
        {
            Service = service;
        }

        public Task<Model.Common.IPersonInCharge> GetAsync(string id)
        {
            return Service.GetAsync(id);
        }

        public Task<Model.Common.IPersonInCharge> GetCurrentAsync()
        {
            return Service.GetCurrentAsync();
        }

        public Task<int> AddAsync(Model.Common.IPersonInCharge pic)
        {
            return Service.AddAsync(pic);
        }

        public Task<int> UpdateAsync(Model.Common.IPersonInCharge pic)
        {
            return Service.UpdateAsync(pic);
        }

        public Task<int> DeleteAsync(Model.Common.IPersonInCharge pic)
        {
            return Service.DeleteAsync(pic);
        }
    }
}
