using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Dtos;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class AccordionController : Controller
    {
        public AccordionController()
        {

        }

        [HttpGet]
        public IActionResult Index(string primeiroAccordionId = "", string segundoAccordionId = "")
        {
            // Lista 1 de pessoas
            var lista1 = new List<Pessoa>
        {
            new Pessoa(1, "João Silva", "São Paulo"),
            new Pessoa(2, "Maria Oliveira", "Rio de Janeiro"),
            new Pessoa(3, "Pedro Santos", "Belo Horizonte"),
            new Pessoa(4, "Ana Souza", "Curitiba"),
            new Pessoa(5, "Carlos Lima", "Porto Alegre"),
            new Pessoa(6, "Mariana Costa", "Recife")
        };

            // Lista 2 de pessoas
            var lista2 = new List<Pessoa>
        {
            new Pessoa(7, "Roberto Alves", "Salvador"),
            new Pessoa(8, "Fernanda Martins", "Fortaleza"),
            new Pessoa(9, "Paulo Rocha", "Brasília"),
            new Pessoa(10, "Carla Ferreira", "Manaus"),
            new Pessoa(11, "Rafael Gonçalves", "Belém"),
            new Pessoa(12, "Juliana Almeida", "Florianópolis")
        };

            var pessoaDto = new PessoasDto(lista1, lista2, primeiroAccordionId, segundoAccordionId);
            return View(pessoaDto);
        }

        [HttpPost]
        public IActionResult Create(string primeiroAccordionId, string segundoAccordionId)
        {
            return RedirectToAction("Index", new { primeiroAccordionId = primeiroAccordionId, segundoAccordionId = segundoAccordionId });
        }
    }
}
