using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class SobreController : Controller
    {
        public SobreController()
        {

        }

        [Breadcrumb(Title = "haha")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb(Title = "123")]
        public IActionResult Teste()
        {
            return View();
        }

        [Breadcrumb(Title = "ok", FromAction = "Teste", FromController = typeof(SobreController))]
        public IActionResult Teste1()
        {
            return View();
        }
    }
}
