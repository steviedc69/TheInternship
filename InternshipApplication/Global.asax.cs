using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using InternshipApplication.Infrastructure;
using InternshipApplication.Models;
using InternshipApplication.Models.DAL;
using InternshipApplication.Models.Domain;

namespace InternshipApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(Bedrijf), new BedrijfModelBinder());
            ModelBinders.Binders.Add(typeof(Stagebegeleider), new StageModelBinder());
            ModelBinders.Binders.Add(typeof(Student), new StudentModelBinder());
            Database.SetInitializer<InternshipContext>(new InternshipInitializer());
            new InternshipContext().Bedrijven.ToList();
            

            
            

        }
    }
}