using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class DataAnnotationController : Controller
    {
        public DataAnnotationController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            var alunos = CriarListaAlunos();

            return View(alunos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            //Da para deixar campo nome hidden e o JS nao ira validar, mas tem que remover da modal state
            ModelState.Remove(nameof(Aluno.Nome));
            ModelState.Remove("EmailConfirmacao");

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Nome,DataNascimento,Email,Avaliacao,Ativo")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao");

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private static List<Aluno> CriarListaAlunos()
        {
            return new List<Aluno>
        {
            new Aluno
            {
                Id = 1,
                Nome = "João Silva",
                DataNascimento = new DateTime(2000, 5, 15),
                Email = "joao.silva@example.com",
                EmailConfirmacao = "joao.silva@example.com",
                Avaliacao = 4,
                Ativo = true,
                Saldo = 10555.50m
            },
            new Aluno
            {
                Id = 2,
                Nome = "Maria Souza",
                DataNascimento = new DateTime(1999, 8, 20),
                Email = "maria.souza@example.com",
                EmailConfirmacao = "maria.souza@example.com",
                Avaliacao = 5,
                Ativo = true,
                Saldo = 1500.00m
            },
            new Aluno
            {
                Id = 3,
                Nome = "Carlos Pereira",
                DataNascimento = new DateTime(2001, 1, 10),
                Email = "carlos.pereira@example.com",
                EmailConfirmacao = "carlos.pereira@example.com",
                Avaliacao = 3,
                Ativo = true,
                Saldo = 100000.00m
            },
            new Aluno
            {
                Id = 4,
                Nome = "Ana Lima",
                DataNascimento = new DateTime(2000, 12, 25),
                Email = "ana.lima@example.com",
                EmailConfirmacao = "ana.lima@example.com",
                Avaliacao = 4,
                Ativo = true,
                Saldo = 50300.00m
            },
            new Aluno
            {
                Id = 5,
                Nome = "Pedro Albuquerque",
                DataNascimento = new DateTime(1998, 7, 5),
                Email = "pedro.albuquerque@example.com",
                EmailConfirmacao = "pedro.albuquerque@example.com",
                Avaliacao = 2,
                Ativo = true,
                Saldo = 50000.00m
            },
            new Aluno
            {
                Id = 6,
                Nome = "Mariana Santos",
                DataNascimento = new DateTime(2002, 9, 15),
                Email = "mariana.santos@example.com",
                EmailConfirmacao = "mariana.santos@example.com",
                Avaliacao = 5,
                Ativo = true,
                Saldo = 50000.00m
            }
        };

        }
    }
}
