﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin.Host;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace WebAPIAssignments
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //string baseAddress = "http://localhost:50275/";
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{

            //    HttpClient client = new HttpClient();
            //    var response = client.GetAsync(baseAddress + "api/values").Result;
            //}
        }
    }
}