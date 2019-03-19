namespace fpReceitas.Core.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ModoDePreparo { get; set; }
        public string Ingredientes { get; set; }
    }
}
