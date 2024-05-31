using System.ComponentModel.DataAnnotations;
using TestTabelaResponivaBoostrap.Models.Enums;

namespace TestTabelaResponivaBoostrap.Models
{
    public class Mes
    {
        [Range(1, 7, ErrorMessage = "Selecionar um dia da semana.")]
        public EDiasSemana DiasSemana { get; set; }
    }
}
