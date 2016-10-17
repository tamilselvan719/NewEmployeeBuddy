using NewEmployeeBuddy.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace NewEmployeeBuddy.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //To specify the initializer class that will seed the initial data everytime a model changes
            Database.SetInitializer(new DbContextInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
