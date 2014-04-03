using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Books
{
    using System.Configuration;
    using System.Web.Hosting;

    using Books.IoC;
    using Books.Models;

    using Microsoft.Practices.Unity;

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

		    var xmlPath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings.Get("XmlPath"));
		    var conteiner = new UnityContainer();
            conteiner.RegisterType<IBookService, BookService>(new InjectionConstructor(xmlPath));

            IDependencyResolver resolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(new UnityDependencyResolver(conteiner, resolver)); 
		}
	}
}