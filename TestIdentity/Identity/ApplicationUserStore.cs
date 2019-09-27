using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestIdentity.Identity
{
    public class ApplicationUserStore :UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDBContext dbContext):base(dbContext)
        {

        }
    }
}