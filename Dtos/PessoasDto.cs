using TestTabelaResponivaBoostrap.Models;

namespace TestTabelaResponivaBoostrap.Dtos
{
    public class PessoasDto
    {
        public List<Pessoa> ListaPessoa1 { get; set; } = new List<Pessoa>();
        public List<Pessoa> ListaPessoa2 { get; set; } = new List<Pessoa>();
        public string PrimeiroAccordionId { get; set; } = string.Empty;
        public string SegundoAccordionId { get; set; } = string.Empty;

        public PessoasDto()
        {

        }

        public PessoasDto(
            List<Pessoa> listaPessoa1,
            List<Pessoa> listaPessoa2,
            string primeiroAccordionId,
            string segundoAccordionId)
        {
            ListaPessoa1=listaPessoa1;
            ListaPessoa2=listaPessoa2;
            PrimeiroAccordionId=primeiroAccordionId;
            SegundoAccordionId=segundoAccordionId;
        }
    }
}
