using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Extensions.Interception;
using Lost.Common;

namespace Lost.UI
{
    public class GreedyController : ILostInterceptor
    {
        // GET: Greedy
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name.Equals("DeleteMissingPerson"))
            {
                invocation.ReturnValue = false;
                return;
            }
            invocation.Proceed();
        }
    }
}