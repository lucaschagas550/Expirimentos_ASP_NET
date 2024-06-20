using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Dtos;
using TestTabelaResponivaBoostrap.Models;
using TestTabelaResponivaBoostrap.Utils;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class TableModalNotSendController : Controller
    {
        public TableModalNotSendController()
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var alunosCidadeDto = new AlunoCidadeDto();

            return View(alunosCidadeDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] AlunoCidadeDto alunos)
        {
            //var alunos = JsonExtensions.DeserializeJsonToObject<List<Aluno>>(json);

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            return View(alunos);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create2(Aluno aluno)
        {
            //var alunos = JsonExtensions.DeserializeJsonToObject<List<Aluno>>(json);

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            return View(aluno);
        }
    }
}
