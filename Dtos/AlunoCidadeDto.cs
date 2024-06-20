using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Dtos
{
    public class AlunoCidadeDto
    {
        public List<Aluno> Aluno{ get; set; } = new List<Aluno>();
        public Endereco Endereco { get; set; } = new Endereco();
    }
}
