namespace TestTabelaResponivaBoostrap.Models
{
    public class EditorTexto
    {
        public EditorTexto(string content)
        {
            Content = content;
        }

        public EditorTexto()
        {
            
        }

        public string Content { get; set; } = string.Empty;
    }
}
