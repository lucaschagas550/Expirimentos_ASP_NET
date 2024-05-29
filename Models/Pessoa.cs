namespace TestTabelaResponivaBoostrap.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public Pessoa()
        {
            
        }

        public Pessoa(string nome, string cidade)
        {
            Nome = nome;
            Cidade = cidade;
        }
    }
}
