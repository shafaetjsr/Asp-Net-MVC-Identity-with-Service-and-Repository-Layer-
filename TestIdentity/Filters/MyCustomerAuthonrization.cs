﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestIdentity.Filters
{
    public class MyCustomerAuthonrization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("Customer")==false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}