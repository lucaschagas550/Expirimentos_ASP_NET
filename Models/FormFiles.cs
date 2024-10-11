using System.ComponentModel.DataAnnotations;

namespace TestTabelaResponivaBoostrap.Models
{
    public class FormFiles
    {
        [Required(ErrorMessage = "Inserir arquivos")]
        public Files Arquivos { get; set; } = new Files();
    }

    public class Files
    {
        [Required(ErrorMessage ="Inserir arquivos")]
        public List<IFormFile>? FormFiles { get; set; } = new List<IFormFile>();
    }
}
