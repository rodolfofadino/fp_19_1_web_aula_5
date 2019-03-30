using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpReceitas.Web.Models
{
    public class Boleto
    {
        public  int Id { get; set; }
        public  Boolean Remover { get; set; }
    }

    public class ViewModelBoleto
    {
        public  List<Boleto> Boletos { get; set; }
    }
}
