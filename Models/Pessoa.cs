namespace TestTabelaResponivaBoostrap.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Pais{ get; set; }

        public Pessoa()
        {
            
        }

        public Pessoa(string nome, string cidade, string pais)
        {
            Nome = nome;
            Cidade = cidade;
            Pais = pais;
        }

        public Pessoa(string nome, string cidade)
        {
            Nome = nome;
            Cidade = cidade;
        }

        public Pessoa(int id, string nome, string cidade)
        {
            Id=id;
            Nome=nome;
            Cidade=cidade;
        }
    }
}
