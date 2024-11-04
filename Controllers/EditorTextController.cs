using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Controllers.Base;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class EditorTextController : MainController
    {
        public static EditorTexto textoPublic = new EditorTexto("<p><b>Teste</b></p>");

        public EditorTextController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(textoPublic);
        }

        [HttpPost]
        public IActionResult Create(EditorTexto editorTexto)
        {
            textoPublic.Content = editorTexto.Content;

            return RedirectToAction("Index");
        }
    }
}
