using Microsoft.AspNetCore.Mvc;

namespace RiskAnalysis.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
