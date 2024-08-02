using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using TestTabelaResponivaBoostrap.Models;
using TestTabelaResponivaBoostrap.Models.Enums;
using TestTabelaResponivaBoostrap.Utils;

namespace TestTabelaResponivaBoostrap.Controllers
{
    //[DefaultBreadcrumb("My home",  FromController = typeof(HomeController), FromAction = "Index", IconClasses = "<i class=\"fs-6 bi bi-house\" style=\"color: black;\"></i>")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [DefaultBreadcrumb("My home", IconClasses = "<i class=\"fs-6 bi bi-house\" style=\"color: black;\"></i>")]
        public IActionResult Index()
        {
            var pessoa = new Pessoa() { Nome = "test", Cidade = "city" };
            Response.Cookies.Append("nomeDoCookie", SerializeObjectToJson(pessoa), new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(1),
                IsEssential = true
            });

            var cookieResponse = Request.Cookies["nomeDoCookie"];
            if (cookieResponse is not null)
            {
                var pessoaCookie = DeserializeJsonToObject<Pessoa>(cookieResponse);
            }

            var pessoas = new List<Pessoa>() {
                new Pessoa("test 1", "test 1"),
                new Pessoa("test 2", "test 2"),
                new Pessoa("test 3", "test 3"),
            };

            ViewBag.Paises = new SelectList(pessoas,
                "Nome",
                "Cidade");


            var startYear = 1950;
            var currentYear = DateTime.Now.Year;
            ViewBag.Ano = Enumerable.Range(startYear, currentYear - startYear + 1)
                                  .OrderByDescending(x => x)
                                  .Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() })
                                  .ToList();


            CriarViewBag();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> File(FileModel fileModel)
        {
            //file.ContentType Coluna no banco
            //file.Name Coluna no banco, nao tem o tipo do arquivo, ou seja eh sem o .pdf por exemplo, somente o nome

            // Converter bytes para megabytes (MB)
            var fileSizeInMB = Math.Round((double)fileModel.File.Length / (1024 * 1024), 3).ToString() + " MB"; // 1 MB = 1024 * 1024 bytes
            using var ms = new MemoryStream();
            await fileModel.File.CopyToAsync(ms);
            var fileBytes = ms.ToArray();

            // Converter os bytes para uma string Base64
            string base64String = Convert.ToBase64String(fileBytes);

            // Agora, 'base64String' contém a representação Base64 do arquivo
            // Faça o que quiser com 'base64String', como salvá-lo no banco de dados ou usá-lo em outro lugar.

            return View("Success"); // Retorne uma view de sucesso ou outra resposta apropriada
            return View(fileModel);
        }

        [HttpPost]
        public FileResult Download(string fileName)
        {
            //Buscar o arquivo no banco pelo nome, o padrao deve ser Id-NomeArquivo.Tipo
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var servicesDirectory = Path.GetDirectoryName(assemblyLocation);

            //Obter o base64 que estara no banco e retornar
            var path = Path.Combine(servicesDirectory, fileName);
            var filebase64 = "PHRhYmxlIGNsYXNzPSJ0YWJsZSI+DQogICAgPHRoZWFkPg0KICAgICAgICA8dHI+DQogICAgICAgICAgICA8dGg+Tm9tZTwvdGg+DQogICAgICAgICAgICA8dGg+RGV0YWxoZXM8L3RoPg0KICAgICAgICA8L3RyPg0KICAgIDwvdGhlYWQ+DQogICAgPHRib2R5Pg0KICAgICAgICA8dHI+DQogICAgICAgICAgICA8dGQ+SXRlbSAxPC90ZD4NCiAgICAgICAgICAgIDx0ZD4NCiAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPSJhY2NvcmRpb24iIGlkPSJhY2NvcmRpb25JdGVtMSI+DQogICAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9ImFjY29yZGlvbi1pdGVtIj4NCiAgICAgICAgICAgICAgICAgICAgICAgIDxoMiBjbGFzcz0iYWNjb3JkaW9uLWhlYWRlciIgaWQ9ImhlYWRpbmdJdGVtMSI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgPGJ1dHRvbiBjbGFzcz0iYWNjb3JkaW9uLWJ1dHRvbiIgdHlwZT0iYnV0dG9uIiBkYXRhLWJzLXRvZ2dsZT0iY29sbGFwc2UiIGRhdGEtYnMtdGFyZ2V0PSIjY29sbGFwc2VJdGVtMSIgYXJpYS1leHBhbmRlZD0iZmFsc2UiIGFyaWEtY29udHJvbHM9ImNvbGxhcHNlSXRlbTEiPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBEZXRhbGhlcyBkbyBJdGVtIDENCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L2J1dHRvbj4NCiAgICAgICAgICAgICAgICAgICAgICAgIDwvaDI+DQogICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGlkPSJjb2xsYXBzZUl0ZW0xIiBjbGFzcz0iYWNjb3JkaW9uLWNvbGxhcHNlIGNvbGxhcHNlIiBhcmlhLWxhYmVsbGVkYnk9ImhlYWRpbmdJdGVtMSIgZGF0YS1icy1wYXJlbnQ9IiNhY2NvcmRpb25JdGVtMSI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iYWNjb3JkaW9uLWJvZHkiPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDb250ZcO6ZG8gZGV0YWxoYWRvIGRvIEl0ZW0gMS4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L2Rpdj4NCiAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2Pg0KICAgICAgICAgICAgICAgICAgICA8L2Rpdj4NCiAgICAgICAgICAgICAgICA8L2Rpdj4NCiAgICAgICAgICAgIDwvdGQ+DQogICAgICAgIDwvdHI+DQoNCiAgICAgICAgPHRyPg0KICAgICAgICAgICAgPHRkPkl0ZW0gMjwvdGQ+DQogICAgICAgICAgICA8dGQ+DQogICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iYWNjb3JkaW9uIiBpZD0iYWNjb3JkaW9uSXRlbTIiPg0KICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPSJhY2NvcmRpb24taXRlbSI+DQogICAgICAgICAgICAgICAgICAgICAgICA8aDIgY2xhc3M9ImFjY29yZGlvbi1oZWFkZXIiIGlkPSJoZWFkaW5nSXRlbTIiPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxidXR0b24gY2xhc3M9ImFjY29yZGlvbi1idXR0b24iIHR5cGU9ImJ1dHRvbiIgZGF0YS1icy10b2dnbGU9ImNvbGxhcHNlIiBkYXRhLWJzLXRhcmdldD0iI2NvbGxhcHNlSXRlbTIiIGFyaWEtZXhwYW5kZWQ9InRydWUiIGFyaWEtY29udHJvbHM9ImNvbGxhcHNlSXRlbTIiPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBEZXRhbGhlcyBkbyBJdGVtIDINCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L2J1dHRvbj4NCiAgICAgICAgICAgICAgICAgICAgICAgIDwvaDI+DQogICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGlkPSJjb2xsYXBzZUl0ZW0yIiBjbGFzcz0iYWNjb3JkaW9uLWNvbGxhcHNlIGNvbGxhcHNlIHNob3ciIGFyaWEtbGFiZWxsZWRieT0iaGVhZGluZ0l0ZW0yIiBkYXRhLWJzLXBhcmVudD0iI2FjY29yZGlvbkl0ZW0yIj4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzPSJhY2NvcmRpb24tYm9keSI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENvbnRlw7pkbyBkZXRhbGhhZG8gZG8gSXRlbSAyLg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvZGl2Pg0KICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+DQogICAgICAgICAgICAgICAgICAgIDwvZGl2Pg0KICAgICAgICAgICAgICAgIDwvZGl2Pg0KICAgICAgICAgICAgPC90ZD4NCg0KICAgICAgICAgICAgPHRkPg0KICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9ImFjY29yZGlvbiIgaWQ9ImFjY29yZGlvbkl0ZW0zIj4NCiAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iYWNjb3JkaW9uLWl0ZW0iPg0KICAgICAgICAgICAgICAgICAgICAgICAgPGgyIGNsYXNzPSJhY2NvcmRpb24taGVhZGVyIiBpZD0iaGVhZGluZ0l0ZW0zIj4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8YnV0dG9uIGNsYXNzPSJhY2NvcmRpb24tYnV0dG9uIiB0eXBlPSJidXR0b24iIGRhdGEtYnMtdG9nZ2xlPSJjb2xsYXBzZSIgZGF0YS1icy10YXJnZXQ9IiNjb2xsYXBzZUl0ZW0zIiBhcmlhLWV4cGFuZGVkPSJ0cnVlIiBhcmlhLWNvbnRyb2xzPSJjb2xsYXBzZUl0ZW0zIj4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRGV0YWxoZXMgZG8gSXRlbSAzDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgPC9idXR0b24+DQogICAgICAgICAgICAgICAgICAgICAgICA8L2gyPg0KICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBpZD0iY29sbGFwc2VJdGVtMyIgY2xhc3M9ImFjY29yZGlvbi1jb2xsYXBzZSBjb2xsYXBzZSBzaG93IiBhcmlhLWxhYmVsbGVkYnk9ImhlYWRpbmdJdGVtMyIgZGF0YS1icy1wYXJlbnQ9IiNhY2NvcmRpb25JdGVtMyI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iYWNjb3JkaW9uLWJvZHkiPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDb250ZcO6ZG8gZGV0YWxoYWRvIGRvIEl0ZW0gMy4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRhYmxlIGNsYXNzPSJ0YWJsZSI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGhlYWQ+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRyPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGg+Q29sdW5hIDE8L3RoPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGg+Q29sdW5hIDI8L3RoPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGg+Q29sdW5hIDM8L3RoPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvdHI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L3RoZWFkPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRib2R5Pg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDx0cj4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRkPkRhZG9zIDE8L3RkPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGQ+RGFkb3MgMjwvdGQ+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDx0ZD5EYWRvcyAzPC90ZD4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8L3RyPg0KDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRyPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8dGQ+RGFkb3MgMTwvdGQ+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDx0ZD5EYWRvcyAyPC90ZD4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPHRkPkRhZG9zIDM8L3RkPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvdHI+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgPCEtLSBBZGljaW9uZSBtYWlzIGxpbmhhcyBjb25mb3JtZSBuZWNlc3PDoXJpbyAtLT4NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvdGJvZHk+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDwvdGFibGU+DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgPC9kaXY+DQogICAgICAgICAgICAgICAgICAgICAgICA8L2Rpdj4NCiAgICAgICAgICAgICAgICAgICAgPC9kaXY+DQogICAgICAgICAgICAgICAgPC9kaXY+DQogICAgICAgICAgICA8L3RkPg0KICAgICAgICA8L3RyPg0KICAgICAgICA8IS0tIEFkaWNpb25lIG1haXMgbGluaGFzIGNvbmZvcm1lIG5lY2Vzc8OhcmlvIC0tPg0KICAgIDwvdGJvZHk+DQo8L3RhYmxlPg0K";
            var fileBytes = Convert.FromBase64String(filebase64);


            //Joguei o arquivo na raiz do bin em tempo de execucao
            //var template = System.IO.File.ReadAllBytes(Path.Combine(servicesDirectory, fileName));

            return File(fileBytes,
                "text/html", //file.ContentType Coluna no banco
                $"{fileName}.html", true);
        }

        [HttpGet("GetExcel")]
        public FileResult GetExcel(int id)
        {
            //Instalar a lib ClosedXML
            // Simulando uma lista de dados para exportar
            var data = new List<dynamic> {
                new { Name = "João", Age = 29, Email = "joao@example.com" },
                new { Name = "Maria", Age = 34, Email = "maria@example.com" }
            };

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Data");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Name";
                worksheet.Cell(currentRow, 2).Value = "Age";
                worksheet.Cell(currentRow, 3).Value = "Email";

                foreach (var item in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Name;
                    worksheet.Cell(currentRow, 2).Value = item.Age;
                    worksheet.Cell(currentRow, 3).Value = item.Email;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"Export_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.xlsx" //Nome do arquivo gerado
                    };
                }
            }
        }

        //[Breadcrumb(FromAction = "Index", Title = "Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ReceiveSelectedCountries(List<string> selectedCountries)
        {
            // Process the selected countries
            // For example, you can log them or perform some business logic
            foreach (var country in selectedCountries)
            {
                // Do something with each country
            }

            // Return a view or a JSON response
            return View();
        }

        [HttpPost]
        public IActionResult ValidarModelStateSelectList(Mes mes)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine($"Dia semana eh {mes}");
                return View("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult RecebeDiaSemana(EDiasSemana diasSemana)
        {
            if (diasSemana == 0)
            {
                Console.WriteLine($"Dia semana eh {diasSemana}");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Radio(EClassificacao radioId)
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult AnoSelecionado(string ano)
        {
            Console.WriteLine(ano);
            return RedirectToAction("Index");
        }

        protected string SerializeObjectToJson(object data) =>
           JsonSerializer.Serialize(data);

        protected T? DeserializeJsonToObject<T>(string responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(responseMessage, options);
        }

        private void CriarViewBag()
        {
            ViewBag.DiasSemana = new SelectList(
            Enum.GetValues(typeof(EDiasSemana))
                .Cast<EDiasSemana>()
                .Where(d => d != EDiasSemana.NenhumItemSelecionado)
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = EnumHelper<EDiasSemana>.GetDisplayValue(e)
                }), "Value", "Text");
        }
    }
}
