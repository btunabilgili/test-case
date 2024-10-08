using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RiskAnalysis.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
