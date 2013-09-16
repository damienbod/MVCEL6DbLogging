using System.Web.Mvc;
using MvcEL6Test.Logger;

namespace MvcEL6Test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            BasicLogger.Log.ErrorWithKeywordsControllerAction("Error With Keywords ControllerAction");
            BasicLogger.Log.ErrorWithKeywordsControllerActionAndKeywordsPage("Error With Keywords ControllerAction And Keywords Page");
            BasicLogger.Log.ErrorWithKeywordsDiagnosticStartStop("Error With Keywords DiagnosticStartStop");
            BasicLogger.Log.ErrorWithNoKeywordsDefined("Error With No Keywords Defined");

            BasicLogger.Log.WarningWithEventTaskAmazingTask("WarningWithEventTaskAmazingTask");
            BasicLogger.Log.WarningWithEventTaskPage("WarningWithEventTaskPage");
            BasicLogger.Log.WarningWithNoEventTaskDefined("WarningWithNoEventTaskDefined");

            BasicLogger.Log.WarningWithOpcodePage("WarningWithOpcodePage");
            
            return View();
        }

    }
}
