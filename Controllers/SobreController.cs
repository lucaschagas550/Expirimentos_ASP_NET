using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class SobreController : Controller
    {
        public SobreController()
        {

        }

        [Breadcrumb(Title = "Sobre", IconClasses = "<i class=\"fs-6 bi bi-house\" style=\"color: black;\"></i>")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb(Title = "123")]
        public IActionResult Teste()
        {
            return View();
        }

        //Obter valor da ViewData podendo ser um nome de um produto por exemplo da paginal final do breadcrump
        [Breadcrumb("ViewData.Breadcrumb", FromAction = "Teste", FromController = typeof(SobreController))]
        public IActionResult Teste1()
        {
            ViewData["Breadcrumb"] = "Action 1";
            return View();
        }

        public IActionResult RedirectToInfo()
        {
            return RedirectToAction("Index", "Info");
        }
    }
}
