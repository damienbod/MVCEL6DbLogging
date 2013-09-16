using System.Diagnostics.Tracing;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using MvcEL6Test.Logger;

namespace MvcEL6Test
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public const EventKeywords ControllerAction = (EventKeywords)16;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var sqlListener = SqlDatabaseLog.CreateListener("HomeController", "Data Source=.;Initial Catalog=Logging;Integrated Security=True");
            sqlListener.EnableEvents(BasicLogger.Log, EventLevel.Warning);

            // Only listerner for events with Keyword ControllerAction or none defined
            //sqlListener.EnableEvents(BasicLogger.Log, EventLevel.Error,ControllerAction);

        }
    }
}