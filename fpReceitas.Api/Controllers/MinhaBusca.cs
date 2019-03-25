using System.ComponentModel.DataAnnotations;

namespace fpReceitas.Api.Controllers
{
    public class MinhaBusca
    {
        [Required]
        public string Texto { get; set; }
        public string Nome { get; set; }
    }
}