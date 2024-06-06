using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Controllers
{
	public class FormController : Controller
	{
        public FormController()
        {
            
        }

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


        //Testar com data e boolean
        [HttpPost]
        public IActionResult Index(string email, double price, bool flexRadioDefault)
        {
            return View();
        }

    }
}
