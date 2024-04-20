using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class InfoController : Controller
    {
        public InfoController()
        {
            
        }

        [Breadcrumb(Title = "Info", FromAction = "Teste1", FromController = typeof(SobreController))]
        public IActionResult Index()
        {
            return RedirectToAction("Teste", "Sobre");
            return View();
        }

    }
}
