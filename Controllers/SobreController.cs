using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
    //[Breadcrumb(Title = "haha")]
    public class SobreController : Controller
    {
        public SobreController()
        {
            
        }

        //[Breadcrumb("Sobre")]
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
    }
}
