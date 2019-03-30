using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpReceitas.Core.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
        public string Imagem { get; set; }
        public string Url { get; set; }
        public string DescricaoImagem { get; set; }
    }
}
