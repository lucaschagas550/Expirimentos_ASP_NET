using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Controllers.Base;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
    public class FormController : MainController
    {
        public FormController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            SessionCreateKeyValue("Test", new Aluno() { Email = "teste@123" });
            
            var sessionValue = GetSessionValue<Aluno>("Test"); //Vem Preenchido,
            var test = GetSessionValue<Pessoa>("Test"); //Vem com objeto mas null as propriedades pq a key existe mas o objeto nao eh do tipo correto
            var test2 = GetSessionValue<Aluno>("Test2"); //Vem null pq nao existe
            //Sugestao, add propriedade onde se passa um boolean falando para pegar os valores do session GetValueSession = true
            //Buscar pela key como nome filtro, se o filtro atual for null e se o retorno do session for diferente de null setar os valores na filtro atual

            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, double price, bool flexRadioDefault, DateTime data, string name)
        {
            return View();
        }

    }
}
