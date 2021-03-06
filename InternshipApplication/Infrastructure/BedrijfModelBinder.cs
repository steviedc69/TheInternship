﻿using System;
using System;
using System.Web.Mvc;
using InternshipApplication.Models.DAL;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Infrastructure
{
    public class BedrijfModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            if (controllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IBedrijfRepository repos =
                    (IBedrijfRepository) DependencyResolver.Current.GetService(typeof (IBedrijfRepository));
                return repos.FindByEmail(controllerContext.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}
